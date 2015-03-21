using System;
using System.Windows;
using System.Windows.Forms;
using TotalPhase;


namespace PowerCyclingFunctions
{
    class Aardvark
    {
        /*=========================================================================
        | I2C Power Cycling Command Registers
        ========================================================================*/
        public enum I2CCommands: int
        {
            PC_T1_COUNT_LSB_CMD     = 0x20,		//Power ON duration (LSB) before power OFF command
            PC_T1_COUNT_MSB_CMD    	= 0x21, 	//Power ON duration (MSB)before power OFF command
            PC_T2_COUNT_LSB_CMD    	= 0x22, 	//Power OFF duration (LSB) command
            PC_T2_COUNT_MSB_CMD    	= 0x23, 	//Power OFF duration (MSB)command
            PC_T3_COUNT_LSB_CMD    	= 0x24, 	//Power ON duration (LSB) after power OFF command
            PC_T3_COUNT_MSB_CMD    	= 0x25, 	//Power ON duration (MSB) after power OFF command
            PC_COUNT_LSB_CMD        = 0x26,		//Number of power cycling command (LSB)
            PC_COUNT_MSB_CMD        = 0x27, 	//Number of power cycling command (MSB)
            PC_STATUS_CMD           = 0x28, 	//Power cylcing status register
            PC_T1_SET_LSB_CMD       = 0x29, 	//Power ON duration set (LSB) before power OFF command
            PC_T1_SET_MSB_CMD       = 0x2A, 	//Power ON duration set (MSB)before power OFF command
            PC_T2_SET_LSB_CMD       = 0x2B, 	//Power OFF duration set (LSB) command
            PC_T2_SET_MSB_CMD       = 0x2C, 	//Power OFF duration set (MSB)command
            PC_T3_SET_LSB_CMD       = 0x2D, 	//Power ON duration set (LSB) after power OFF command
            PC_T3_SET_MSB_CMD       = 0x2E, 	//Power ON duration set (MSB) after power OFF command
            PC_COUNT_SET_LSB_CMD    = 0x2F, 	//Number of power set cycling command (LSB)
            PC_COUNT_SET_MSB_CMD    = 0x30, 	//Number of power set cycling command (MSB)
            PC_RESET_CMD            = 0x31, 	//Reset/set counts and enable/disable MOSFET
            PC_INCDEC_MODE_CMD      = 0x32, 	//Enable/disable inc/dec dropout test
            CALIBRATION_CMD         = 0x70,		//Allow EEPROM write
            CALIBRATION_ACTIVE      = 0xAA,	    //Allow EEPROM write
            CALIBRATION_DONE        = 0xCC,	    //Save data received to EEPROM
            MSB_BYTE                = 0x00      //MSB byte for 16-bit i2c data transmit
        }
        private ushort[] ports = new ushort[16];
        private uint[] uniqueIds = new uint[16];
        //private int numElem = 16;
        private int port;

        /*=========================================================================
        | Auto detect Aardvark controller
         ========================================================================*/
        public int Aadetect(TextBox txtMessageCentre)
        {
            int i;
            int numElem = 16;

            int count = AardvarkApi.aa_find_devices_ext(numElem, ports, numElem, uniqueIds);

            txtMessageCentre.Text += count + " device(s) found!" + "\n";

            if (count != 0)
            {
                if (count > numElem) count = numElem;
                // Print the information on each device
                for (i = 0; i < count; ++i)
                {
                    // Determine if the device is in-use
                    string status = "(avail) ";
                    if ((ports[i] & AardvarkApi.AA_PORT_NOT_FREE) != 0)
                    {
                        ports[i] &= unchecked((ushort)~AardvarkApi.AA_PORT_NOT_FREE);
                        status = "(in-use)";
                    }
                    // Display device port number, in-use status, and serial number
                    uint id = unchecked((uint)uniqueIds[i]);

                   txtMessageCentre.Text += "  port = " + ports[i] + ", " + -(id/1000000) + 
                       ", " + status + "\n";
                    //Console.WriteLine("    port={0,-3} {1} ({2:d4}-{3:d6})",
                    //                  ports[i], status, id / 1000000,
                    //                  id % 1000000);
                    port = ports[i];
                } 
            }
            else
            {
                return 99;
            }
            return port;
        }
        /*=========================================================================
        | Initialize Aardvark controller
         ========================================================================*/
        public void InitAardvark(int port, TextBox txtMessageCentre)
        {
            int handle;
            const int bitrate = 100;

            txtMessageCentre.Text += "Aardvark Handle: " + port + "\n";
            if (port != 99)
            {
                //Get the handle number of the Aardvark I2C/SPI adapter
                handle = AardvarkApi.aa_open(port);

                //Set the pull-up of the I2C/SPI Aardvark adapter to none
                AardvarkApi.aa_i2c_pullup(handle, AardvarkApi.AA_I2C_PULLUP_NONE);

                //Set the configuration to I2C/SPI mode
                AardvarkApi.aa_configure(handle, AardvarkConfig.AA_CONFIG_SPI_I2C);

                //Configure the target power pins
                AardvarkApi.aa_target_power(handle, AardvarkApi.AA_TARGET_POWER_NONE);

                //Configure the bit rate
                AardvarkApi.aa_i2c_bitrate(handle, bitrate);
            }
            else
            {
                txtMessageCentre.Text += "No Aardvark controller is connected!" + "\n";
                txtMessageCentre.Text += "Please connect the controller." + "\n";
            }

        }
    }

    class ReadWriteParameters
    {
        public int length;
        public int width;
        //constructor : method that has the same name as the class. // executes when an object is created.
       
        
        public void ReadParameters()
        { 
 
            Console.WriteLine("Constructor fired"); 
        }

        public void WriteParameters() 
        {







            Console.WriteLine("Constructor fired"); 
        }
    }

    class Miscellaneous
    {
        public string Message(string message)
        {
            message += message + "\n";
            return message;
        }

    }


}
