using System;
using System.Windows;
using System.Windows.Forms;
using TotalPhase;


namespace PowerCyclingFunctions
{
    class Aardvark
    {
        public const byte I2C_ADDRESS = 0x5C;   //MCU I2C address

        /*=========================================================================
        | I2C Power Cycling Command Registers
        ========================================================================*/
        public enum I2CCommands : byte
        {
            PC_T1_COUNT_LSB_CMD     = 0x20,		//Power ON duration (LSB) before power OFF command
            PC_T1_COUNT_MSB_CMD    	= 0x21, 	//Power ON duration (MSB)before power OFF command
            PC_T2_COUNT_LSB_CMD    	= 0x22, 	//Power OFF duration (LSB) command
            PC_T2_COUNT_MSB_CMD    	= 0x23, 	//Power OFF duration (MSB)command
            PC_T3_COUNT_LSB_CMD    	= 0x24, 	//Power ON duration (LSB) after power OFF command
            PC_T3_COUNT_MSB_CMD    	= 0x25, 	//Power ON duration (MSB) after power OFF command
            PC_COUNT_LSB_CMD        = 0x26,		//Number of power cycling command (LSB)
            PC_COUNT_MSB_CMD        = 0x27, 	//Number of power cycling command (MSB)
            PC_STATUS_CMD           = 0x28, 	//Power cycling status register
            PC_T1_SET_LSB_CMD       = 0x29, 	//Power ON duration set (LSB) before power OFF command
            PC_T1_SET_MSB_CMD       = 0x2A, 	//Power ON duration set (MSB)before power OFF command
            PC_T2_SET_LSB_CMD       = 0x2B, 	//Power OFF duration set (LSB) command
            PC_T2_SET_MSB_CMD       = 0x2C, 	//Power OFF duration set (MSB)command
            PC_T3_SET_LSB_CMD       = 0x2D, 	//Power ON duration set (LSB) after power OFF command
            PC_T3_SET_MSB_CMD       = 0x2E, 	//Power ON duration set (MSB) after power OFF command
            PC_COUNT_SET_LSB_CMD    = 0x2F, 	//Number of power set cycling command (LSB)
            PC_COUNT_SET_MSB_CMD    = 0x30, 	//Number of power set cycling command (MSB)
            PC_RESET_CMD            = 0x31, 	//Reset/set counts and enable/disable MOSFET
            PC_INCDEC_MODE_CMD      = 0x32, 	//Enable/disable inc/dec drop-out test
            CALIBRATION_CMD         = 0x70,		//Allow EEPROM write
            CALIBRATION_ACTIVE      = 0xAA,	    //Allow EEPROM write
            CALIBRATION_DONE        = 0xCC,	    //Save data received to EEPROM
            MSB_BYTE                = 0x00      //MSB byte for 16-bit i2c data transmit
        }

        private ushort[] ports = new ushort[16];
        private uint[] uniqueIds = new uint[16];
        private int port;

        /*=========================================================================
        | Auto detect Aardvark controller
         ========================================================================*/
        public int Aadetect(TextBox txtMessageCentre)
        {
            int i;
            int numElem = 16;

            int count = AardvarkApi.aa_find_devices_ext(numElem, ports, numElem, uniqueIds);

            txtMessageCentre.Text += count + " device(s) found!" + "\r\n";

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

                   txtMessageCentre.Text += "     port = " + ports[i] + ", " + status + 
											" (" + id/1000000 + "-" + id%1000000 + ")" + "\r\n";
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

            txtMessageCentre.Text += "Aardvark Handle: " + port + "\r";
            txtMessageCentre.SelectionStart = txtMessageCentre.Text.Length;
            txtMessageCentre.ScrollToCaret();
            txtMessageCentre.Refresh();
            
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
                txtMessageCentre.Text += "No Aardvark controller is connected!" + "\r\n";
                txtMessageCentre.Text += "Please connect the controller." + "\r\n";

            }
        }

        /*=========================================================================
        | Auto detect Aardvark controller
         ========================================================================*/
        public int OpenI2CConnection()
        {
            int count, i;
            int port = 0;
            int handle = 0;
            int numElem = 16;
            //const int bitrate = 100;

            count = AardvarkApi.aa_find_devices_ext(numElem, ports, numElem, uniqueIds);
            if (count != 0)
            {
                if (count > numElem) count = numElem;
                // Print the information on each device
                for (i = 0; i < count; ++i)
                {
                    // Determine if the device is in-use
                    if ((ports[i] & AardvarkApi.AA_PORT_NOT_FREE) != 0)
                    {
                        //Device in-use
                        ports[i] &= unchecked((ushort)~AardvarkApi.AA_PORT_NOT_FREE);
                    }
                    else
                    {
                        //Device port number available
                        port = ports[i];
                    }
                }
                //Configure the I2C controller
                //Get the handle number of the Aardvark I2C/SPI adapter
                handle = AardvarkApi.aa_open(port);
                ////Set the pull-up of the I2C/SPI Aardvark adapter to none
                //AardvarkApi.aa_i2c_pullup(handle, AardvarkApi.AA_I2C_PULLUP_NONE);
                ////Set the configuration to I2C/SPI mode
                //AardvarkApi.aa_configure(handle, AardvarkConfig.AA_CONFIG_SPI_I2C);
                ////Configure the target power pins
                //AardvarkApi.aa_target_power(handle, AardvarkApi.AA_TARGET_POWER_NONE);
                ////Configure the bit rate
                //AardvarkApi.aa_i2c_bitrate(handle, bitrate);
            }
            return handle;
        }
    }

    class ReadWriteData
    {

        public uint ReadData(byte command1, byte command2)
        {
            uint dataRead;
            uint [] dataReadTemp = new uint[4];
            int handle;
            const ushort numberOfBytes = 2;
            byte[] dataOut = new byte[2];
            byte[] dataIn = new byte[2];

            //Create the I2C connection and open the connection
            Aardvark I2CConnection = new Aardvark();
            handle = I2CConnection.OpenI2CConnection();

            /*-------------------------------------------------------------------------------------------------------*/
            dataOut[0] = command1;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     numberOfBytes, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, Aardvark.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    numberOfBytes, dataIn);
            dataReadTemp[0] = (uint)(dataIn[0] & 0x000000FF);
            dataReadTemp[1] = (uint)(dataIn[1] << 8 & 0x0000FF00);
            dataOut[0] = command2;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     numberOfBytes, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, Aardvark.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    numberOfBytes, dataIn);
            dataReadTemp[2] = (uint)(dataIn[0] << 16 & 0x00FF0000);
            dataReadTemp[3] = (uint)(dataIn[1] << 24 & 0xFF000000);
            /*-------------------------------------------------------------------------------------------------------*/
            dataRead = (uint)(dataReadTemp[0] | dataReadTemp[1] |
                                dataReadTemp[2] | dataReadTemp[3]);
            AardvarkApi.aa_close(handle);
            return dataRead;
        }

        public uint WriteData(uint data, byte command1, byte command2) 
        {
            uint dataRead;
            uint[] dataReadTemp = new uint[4];
            int handle;
            const ushort bytesToWrite = 3;
            const ushort bytesToRead = 2;
            byte[] dataOut = new byte[3];
            byte[] dataIn = new byte[2];
            byte[] splitData = new byte[4];

            splitData = BitConverter.GetBytes(data);


            //Create the I2C connection and open the connection
            Aardvark I2CConnection = new Aardvark();
            handle = I2CConnection.OpenI2CConnection();

            /*-------------------------------------------------------------------------------------------------------*/
            //Allow to write on EEPROM
            dataOut[0] = (byte)Aardvark.I2CCommands.CALIBRATION_CMD;
            dataOut[1] = (byte)Aardvark.I2CCommands.CALIBRATION_ACTIVE;
            dataOut[2] = (byte)Aardvark.I2CCommands.MSB_BYTE;
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     bytesToWrite, dataOut);
            AardvarkApi.aa_sleep_ms (10);
            /*-------------------------------------------------------------------------------------------------------*/
            //Write power cycling parameter (least significant word)
            dataOut[0] = command1; 
            dataOut[1] = splitData[0];
            dataOut[2] = splitData[1];
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     bytesToWrite, dataOut);
            AardvarkApi.aa_sleep_ms(10);
            /*-------------------------------------------------------------------------------------------------------*/
            //Write power cycling parameter (most significant word)
            dataOut[0] = command2;
            dataOut[1] = splitData[2];
            dataOut[2] = splitData[3];
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     bytesToWrite, dataOut);
            AardvarkApi.aa_sleep_ms(10);
            /*-------------------------------------------------------------------------------------------------------*/
            //Write on EEPROM
            dataOut[0] = (byte)Aardvark.I2CCommands.CALIBRATION_CMD;
            dataOut[1] = (byte)Aardvark.I2CCommands.CALIBRATION_DONE;
            dataOut[1] = (byte)Aardvark.I2CCommands.MSB_BYTE;
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     bytesToWrite, dataOut);
            AardvarkApi.aa_sleep_ms(10);
            /*-------------------------------------------------------------------------------------------------------*/
            dataOut[0] = command1;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     bytesToRead, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, Aardvark.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    bytesToRead, dataIn);
            dataReadTemp[0] = (uint)(dataIn[0] & 0x000000FF);
            dataReadTemp[1] = (uint)(dataIn[1] << 8 & 0x0000FF00);
            dataOut[0] = command2;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     bytesToRead, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, Aardvark.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    bytesToRead, dataIn);
            dataReadTemp[2] = (uint)(dataIn[0] << 16 & 0x00FF0000);
            dataReadTemp[3] = (uint)(dataIn[1] << 24 & 0xFF000000);
            /*-------------------------------------------------------------------------------------------------------*/
            dataRead = (uint)(dataReadTemp[0] | dataReadTemp[1] |
                                dataReadTemp[2] | dataReadTemp[3]);
            AardvarkApi.aa_close(handle);
            return dataRead;
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
