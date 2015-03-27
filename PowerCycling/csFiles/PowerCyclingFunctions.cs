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
            PC_T1COUNT_LSBCMD       = 0x20,		//Power ON duration (LSB) before power OFF command
            PC_T1COUNT_MSBCMD    	= 0x21, 	//Power ON duration (MSB)before power OFF command
            PC_T2COUNT_LSBCMD    	= 0x22, 	//Power OFF duration (LSB) command
            PC_T2COUNT_MSBCMD    	= 0x23, 	//Power OFF duration (MSB)command
            PC_T3COUNT_LSBCMD    	= 0x24, 	//Power ON duration (LSB) after power OFF command
            PC_T3COUNT_MSBCMD    	= 0x25, 	//Power ON duration (MSB) after power OFF command
            PC_CYCLECOUNT_LSBCMD    = 0x26,		//Number of power cycling command (LSB)
            PC_CYCLECOUNT_MSBCMD    = 0x27, 	//Number of power cycling command (MSB)
            PC_STATUS_CMD           = 0x28, 	//Power cycling status register
            PC_T1SET_LSBCMD         = 0x29, 	//Power ON duration set (LSB) before power OFF command
            PC_T1SET_MSBCMD         = 0x2A, 	//Power ON duration set (MSB)before power OFF command
            PC_T2SET_LSBCMD         = 0x2B, 	//Power OFF duration set (LSB) command
            PC_T2SET_MSBCMD         = 0x2C, 	//Power OFF duration set (MSB)command
            PC_T3SET_LSBCMD         = 0x2D, 	//Power ON duration set (LSB) after power OFF command
            PC_T3SET_MSBCMD         = 0x2E, 	//Power ON duration set (MSB) after power OFF command
            PC_CYCLESET_LSBCMD      = 0x2F, 	//Number of power set cycling command (LSB)
            PC_CYCLESET_MSBCMD      = 0x30, 	//Number of power set cycling command (MSB)
            PC_RESET_CMD            = 0x31, 	//Reset/set counts and enable/disable MOSFET
            PC_INCDEC_MODECMD       = 0x32, 	//Enable/disable inc/dec drop-out test
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
/**********************************************************************************************************************/
    class PowerCyclingCom
    {
        /*=========================================================================
        | I2C Power Cycling Command Registers
        ========================================================================*/
        public enum PCI2CCommand : byte
        {
            PC_T1COUNT_LSBCMD       = 0x20,		//Power ON duration (LSB) before power OFF command
            PC_T1COUNT_MSBCMD       = 0x21, 	//Power ON duration (MSB)before power OFF command
            PC_T2COUNT_LSBCMD       = 0x22, 	//Power OFF duration (LSB) command
            PC_T2COUNT_MSBCMD       = 0x23, 	//Power OFF duration (MSB)command
            PC_T3COUNT_LSBCMD       = 0x24, 	//Power ON duration (LSB) after power OFF command
            PC_T3COUNT_MSBCMD       = 0x25, 	//Power ON duration (MSB) after power OFF command
            PC_CYCLECOUNT_LSBCMD    = 0x26,		//Number of power cycling command (LSB)
            PC_CYCLECOUNT_MSBCMD    = 0x27, 	//Number of power cycling command (MSB)
            PC_STATUS_CMD           = 0x28, 	//Power cycling status register
            PC_T1SET_LSBCMD         = 0x29, 	//Power ON duration set (LSB) before power OFF command
            PC_T1SET_MSBCMD         = 0x2A, 	//Power ON duration set (MSB)before power OFF command
            PC_T2SET_LSBCMD         = 0x2B, 	//Power OFF duration set (LSB) command
            PC_T2SET_MSBCMD         = 0x2C, 	//Power OFF duration set (MSB)command
            PC_T3SET_LSBCMD         = 0x2D, 	//Power ON duration set (LSB) after power OFF command
            PC_T3SET_MSBCMD         = 0x2E, 	//Power ON duration set (MSB) after power OFF command
            PC_CYCLESET_LSBCMD      = 0x2F, 	//Number of power set cycling command (LSB)
            PC_CYCLESET_MSBCMD      = 0x30, 	//Number of power set cycling command (MSB)
            PC_RESET_CMD            = 0x31, 	//Reset/set counts and enable/disable MOSFET
            PC_INCDEC_MODECMD       = 0x32, 	//Enable/disable inc/dec drop-out test
            CALIBRATION_CMD         = 0x70		//Allow EEPROM write
        }
        /*=============================================================================================================
        | I2C Power Cycling Command Data
        =============================================================================================================*/
        public enum I2CData : byte
        {
            CALIBRATION_ACTIVE_DATA = 0xAA,	    //Allow EEPROM write
            CALIBRATION_DONE_DATA   = 0xCC,	    //Save data received to EEPROM
            RESET_DISABLE_DATA      = 0xAA,		//Power cycling reset command disable data 
            RESET_ENABLE_DATA       = 0xFF, 	//Power cycling reset command enable data
            INCDEC_DISABLE_DATA     = 0xAA,		//Power cycling increase/decrease command disable data 
            INCDEC_ENABLE_DATA      = 0xFF, 	//Power cycling increase/decrease command enable data 
            MSB_BYTE_DATA           = 0x00,     //MSB byte for 16-bit i2c data transmit
            I2C_ADDRESS             = 0x5C      //MCU I2C address
        }
        /*=============================================================================================================
        | Description: Power cycling status register state
        =============================================================================================================*/
        public enum I2CStatusRegister : byte
        {
            REGSTAT_T1COUNT         = 0x01, 	//Power cycling T1 count done register status 
            REGSTAT_T2COUNT         = 0x02, 	//Power cycling T2 count done register status 
            REGSTAT_T3COUNT         = 0x04, 	//Power cycling T3 count done register status 
            REGSTAT_CYCLECOUNT      = 0x08, 	//Power cycling cycle count done register status 
            REGSTAT_RESET           = 0x10, 	//Power cycling cycle count done register status 
            REGSTAT_INCDEC          = 0x20   	//Power cycling cycle count done register status
        }

        private Aardvark I2CConnection = new Aardvark();
        private uint[] dataReadTemp = new uint[4];
        private byte[] dataIn = new byte[2];
        private uint dataRead;
        private int handle;
        private const ushort NUM_BYTES = 2;
        private const ushort NUM_BYTES_READ = 2;
        private const ushort NUM_BYTES_WRITE = 3;
        /*==============================================================================================================
        | Description: Read single power cycling parameter
        ==============================================================================================================*/
        public uint ReadData(byte command1, byte command2)
        {
            byte[] dataOut = new byte[NUM_BYTES_READ];

            handle = I2CConnection.OpenI2CConnection();
            /*-------------------------------------------------------------------------------------------------------*/
            dataOut[0] = command1;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, (byte)I2CData.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     NUM_BYTES, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, (byte)I2CData.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    NUM_BYTES, dataIn);
            dataReadTemp[0] = (uint)(dataIn[0] & 0x000000FF);
            dataReadTemp[1] = (uint)(dataIn[1] << 8 & 0x0000FF00);
            dataOut[0] = command2;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, (byte)I2CData.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     NUM_BYTES, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, (byte)I2CData.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    NUM_BYTES, dataIn);
            dataReadTemp[2] = (uint)(dataIn[0] << 16 & 0x00FF0000);
            dataReadTemp[3] = (uint)(dataIn[1] << 24 & 0xFF000000);
            /*-------------------------------------------------------------------------------------------------------*/
            dataRead = (uint)(dataReadTemp[0] | dataReadTemp[1] |
                                dataReadTemp[2] | dataReadTemp[3]);
            AardvarkApi.aa_close(handle);
            return dataRead;
        }
        /*==============================================================================================================
        | Description: Write power cycling parameters then read the written parameters
        ==============================================================================================================*/
        public uint WriteData(uint data, byte command1, byte command2) 
        {
            byte[] dataOut = new byte[NUM_BYTES_WRITE];
            byte[] splitData = new byte[4];

            //Spit the int data into array of four bytes data
            splitData = BitConverter.GetBytes(data);
            handle = I2CConnection.OpenI2CConnection();
            /*-------------------------------------------------------------------------------------------------------*/
            //Send the power cycling reset disable command
            dataOut[0] = (byte)PowerCyclingCom.PCI2CCommand.PC_RESET_CMD;
            dataOut[1] = (byte)PowerCyclingCom.I2CData.RESET_DISABLE_DATA;
            dataOut[2] = (byte)PowerCyclingCom.I2CData.MSB_BYTE_DATA;
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     NUM_BYTES_WRITE, dataOut);
            AardvarkApi.aa_sleep_ms(2);
            /*-------------------------------------------------------------------------------------------------------*/
            //Allow to write on EEPROM
            dataOut[0] = (byte)PowerCyclingCom.PCI2CCommand.CALIBRATION_CMD;
            dataOut[1] = (byte)PowerCyclingCom.I2CData.CALIBRATION_ACTIVE_DATA;
            dataOut[2] = (byte)PowerCyclingCom.I2CData.MSB_BYTE_DATA;
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     NUM_BYTES_WRITE, dataOut);
            AardvarkApi.aa_sleep_ms (2);
            /*-------------------------------------------------------------------------------------------------------*/
            //Write power cycling parameter (least significant word)
            dataOut[0] = command1; 
            dataOut[1] = splitData[0];
            dataOut[2] = splitData[1];
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     NUM_BYTES_WRITE, dataOut);
            AardvarkApi.aa_sleep_ms(2);
            /*-------------------------------------------------------------------------------------------------------*/
            //Write power cycling parameter (most significant word)
            dataOut[0] = command2;
            dataOut[1] = splitData[2];
            dataOut[2] = splitData[3];
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     NUM_BYTES_WRITE, dataOut);
            AardvarkApi.aa_sleep_ms(2);
            /*-------------------------------------------------------------------------------------------------------*/
            //Write on EEPROM
            dataOut[0] = (byte)PowerCyclingCom.PCI2CCommand.CALIBRATION_CMD;
            dataOut[1] = (byte)PowerCyclingCom.I2CData.CALIBRATION_DONE_DATA;
            dataOut[2] = (byte)PowerCyclingCom.I2CData.MSB_BYTE_DATA;
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     NUM_BYTES_WRITE, dataOut);
            //20 ms sleep is needed to complete writing the power cycling parameters
            AardvarkApi.aa_sleep_ms(20);
            /*-------------------------------------------------------------------------------------------------------*/
            //Send the power cycling reset enable command
            dataOut[0] = (byte)PowerCyclingCom.PCI2CCommand.PC_RESET_CMD;
            dataOut[1] = (byte)PowerCyclingCom.I2CData.RESET_ENABLE_DATA;
            dataOut[2] = (byte)PowerCyclingCom.I2CData.MSB_BYTE_DATA;
            //Write the I2C address, 1-byte command and 2-bytes of data
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                     NUM_BYTES_WRITE, dataOut);
            AardvarkApi.aa_sleep_ms(2);
            /*-------------------------------------------------------------------------------------------------------*/
            dataOut[0] = command1;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     NUM_BYTES_READ, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, Aardvark.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    NUM_BYTES_READ, dataIn);
            dataReadTemp[0] = (uint)(dataIn[0] & 0x000000FF);
            dataReadTemp[1] = (uint)(dataIn[1] << 8 & 0x0000FF00);
            dataOut[0] = command2;
            //Write the I2C address and 1-byte of command
            AardvarkApi.aa_i2c_write(handle, Aardvark.I2C_ADDRESS,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     NUM_BYTES_READ, dataOut);
            //Write the I2C address and read 2-bytes of data
            AardvarkApi.aa_i2c_read(handle, Aardvark.I2C_ADDRESS,
                                    AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                    NUM_BYTES_READ, dataIn);
            dataReadTemp[2] = (uint)(dataIn[0] << 16 & 0x00FF0000);
            dataReadTemp[3] = (uint)(dataIn[1] << 24 & 0xFF000000);
            /*-------------------------------------------------------------------------------------------------------*/
            dataRead = (uint)(dataReadTemp[0] | dataReadTemp[1] |
                                dataReadTemp[2] | dataReadTemp[3]);
            AardvarkApi.aa_close(handle);
            return dataRead;
        }
    }
    /*===================================================================================================================*/
    class Miscellaneous
    {
        public string Message(string message)
        {
            message += message + "\n";
            return message;
        }

    }


}
