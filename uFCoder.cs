



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    
    
    public enum ERRORCODES
    {

        DL_OK                                   = 0x00,
        COMMUNICATION_ERROR                     = 0x01,
        CHKSUM_ERROR                            = 0x02,
        READING_ERROR                           = 0x03,
        WRITING_ERROR                           = 0x04,
        BUFFER_OVERFLOW                         = 0x05,
        MAX_ADDRESS_EXCEEDED                    = 0x06,
        MAX_KEY_INDEX_EXCEEDED                  = 0x07,
        NO_CARD                                 = 0x08,
        COMMAND_NOT_SUPPORTED                   = 0x09,
        FORBIDEN_DIRECT_WRITE_IN_SECTOR_TRAILER = 0x0A,
        ADDRESSED_BLOCK_IS_NOT_SECTOR_TRAILER   = 0x0B,
        WRONG_ADDRESS_MODE                      = 0x0C,
        WRONG_ACCESS_BITS_VALUES                = 0x0D,
        AUTH_ERROR                              = 0x0E,
        PARAMETERS_ERROR                        = 0x0F,
        MAX_SIZE_EXCEEDED                       = 0x10,
        UNSUPPORTED_CARD_TYPE                   = 0x11,

        COMMUNICATION_BREAK                     = 0x50,
        NO_MEMORY_ERROR                         = 0x51,
        CAN_NOT_OPEN_READER                     = 0x52,
        READER_NOT_SUPPORTED                    = 0x53,
        READER_OPENING_ERROR                    = 0x54,
        READER_PORT_NOT_OPENED                  = 0x55,
        CANT_CLOSE_READER_PORT                  = 0x56,

        WRITE_VERIFICATION_ERROR                = 0x70,
        BUFFER_SIZE_EXCEEDED                    = 0x71,
        VALUE_BLOCK_INVALID                     = 0x72,
        VALUE_BLOCK_ADDR_INVALID                = 0x73,
        VALUE_BLOCK_MANIPULATION_ERROR          = 0x74,
        WRONG_UI_MODE                           = 0x75,
        KEYS_LOCKED                             = 0x76,
        KEYS_UNLOCKED                           = 0x77,
        WRONG_PASSWORD                          = 0x78,
        CAN_NOT_LOCK_DEVICE                     = 0x79,
        CAN_NOT_UNLOCK_DEVICE                   = 0x7A,
        DEVICE_EEPROM_BUSY                      = 0x7B,
        RTC_SET_ERROR                           = 0x7C,
        ANTICOLLISION_DISABLED                  = 0x7D,
        NO_CARDS_ENUMERRATED                    = 0x7E,
        CARD_ALREADY_SELECTED                   = 0x7F,

        FT_STATUS_ERROR_1                       = 0xA0,
        FT_STATUS_ERROR_2                       = 0xA1,
        FT_STATUS_ERROR_3                       = 0xA2,
        FT_STATUS_ERROR_4                       = 0xA3,
        FT_STATUS_ERROR_5                       = 0xA4,
        FT_STATUS_ERROR_6                       = 0xA5,
        FT_STATUS_ERROR_7                       = 0xA6,
        FT_STATUS_ERROR_8                       = 0xA7,
        FT_STATUS_ERROR_9                       = 0xA8

    }
    
       
    unsafe class  uFCoder
    {

#if WIN64
        const string DLL_PATH = "..\\..\\ufr-lib\\windows\\x86_64\\";
        const string NAME_DLL = "uFCoder-x86_64.dll";

#else
        const string DLL_PATH = "..\\..\\ufr-lib\\windows\\x86\\";
        const string NAME_DLL = "uFCoder-x86.dll";
#endif
        const string DLL_NAME = DLL_PATH + NAME_DLL;

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="ReaderOpen" )]
        public static extern DL_STATUS ReaderOpen() ;

        [DllImport( DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="ReaderClose")]
        public static extern DL_STATUS ReaderClose ();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReaderReset")]
        public static extern DL_STATUS ReaderReset();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReaderSoftRestart")]
        public static extern DL_STATUS ReaderSoftRestart();

        [DllImport( DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="GetReaderType" )]
        public static  extern DL_STATUS GetReaderType (ulong* get_reader_type);

         [DllImport( DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto,EntryPoint="ReaderKeyWrite" )]
       public static extern DL_STATUS ReaderKeyWrite(byte* aucKey, byte ucKeyIndex);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetReaderSerialNumber")]
        public  static extern DL_STATUS GetReaderSerialNumber (ulong* serial_number);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetCardId")]
        public static extern DL_STATUS GetCardId(byte* card_type, ulong* card_serial);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetCardIdEx")]
        public static extern DL_STATUS GetCardIdEx(byte* bCardType,
                                                   byte* bCardUid,
                                                   byte* bUidSize);


        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetDlogicCardType")]
        public static extern DL_STATUS GetDlogicCardType(byte* bCardType);



        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReaderUISignal")]
        public static extern DL_STATUS ReaderUISignal(int light_mode, int sound_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ReadUserData")]
        public static extern DL_STATUS ReadUserData(byte* aucData);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "WriteUserData")]
        public static extern DL_STATUS  WriteUserData(byte* aucData);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetReaderHardwareVersion")]
        public static extern DL_STATUS GetReaderHardwareVersion(byte* bVerMajor,
                                                                byte* bVerMinor);
         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetReaderFirmwareVersion")]        
        public static extern DL_STATUS GetReaderFirmwareVersion(byte* bVerMajor,
                                                                byte* bVerMinor);



        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead")]
        public static extern DL_STATUS LinearRead(byte* aucData,
                                                  ushort linear_address,
                                                  ushort data_len,
                                                  ushort* bytes_written,
                                                  byte auth_mode,
                                                  byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead_AKM1")]
        public static extern DL_STATUS LinearRead_AKM1(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead_AKM2")]
        public static extern DL_STATUS LinearRead_AKM2(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearRead_PK")]
        public static extern DL_STATUS LinearRead_PK(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode,
                                                   byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite")]
        public static extern DL_STATUS LinearWrite (byte* aucData,
                                                    ushort linear_address,
                                                    ushort data_len,
                                                    ushort* bytes_written,
                                                    byte auth_mode, 
                                                    byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite_AKM1")]
        public static extern DL_STATUS LinearWrite_AKM1(byte* aucData,
                                                    ushort linear_address,
                                                    ushort data_len,
                                                    ushort* bytes_written,
                                                    byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite_AKM2")]
        public static extern DL_STATUS LinearWrite_AKM2(byte* aucData,
                                                    ushort linear_address,
                                                    ushort data_len,
                                                    ushort* bytes_written,
                                                    byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearWrite_PK")]
        public static extern DL_STATUS LinearWrite_PK(byte* aucData,
                                                   ushort linear_address,
                                                   ushort data_len,
                                                   ushort* bytes_written,
                                                   byte key_mode,
                                                   byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead")]
        public static extern DL_STATUS  BlockRead(byte* data,
                                                  UInt16 block_address,
                                                  byte auth_mode,
                                                  byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead_AKM1")]
        public static extern DL_STATUS BlockRead_AKM1(byte* data,
                                                      UInt16 block_address,
                                                      byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead_AKM2")]
        public static extern DL_STATUS BlockRead_AKM2(byte* data,
                                                      UInt16 block_address,
                                                      byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockRead_PK")]
        public static extern DL_STATUS BlockRead_PK(byte* data,
                                                    UInt16 block_address,
                                                    byte auth_mode,
                                                    byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite")]
        public static extern DL_STATUS BlockWrite(byte* data,
                                                  UInt16 block_address,
                                                  byte auth_mode,
                                                  byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite_AKM1")]
        public static extern DL_STATUS BlockWrite_AKM1(byte* data,
                                                       UInt16 block_address,
                                                       byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite_AKM2")]
        public static extern DL_STATUS BlockWrite_AKM2(byte* data,
                                                       UInt16 block_address,
                                                       byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockWrite_PK")]
        public static extern DL_STATUS BlockWrite_PK(byte* data,
                                                     UInt16 block_address,
                                                     byte auth_mode,
                                                     byte* pk_key);



         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead")]
          public static extern DL_STATUS BlockInSectorRead(byte* data,
                                                           byte sector_address,
                                                           byte block_in_sector_address,
                                                           byte auth_mode,byte key_index);


         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead_AKM1")]
         public static extern DL_STATUS BlockInSectorRead_AKM1(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);


         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead_AKM2")]
         public static extern DL_STATUS BlockInSectorRead_AKM2(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorRead_PK")]
         public static extern DL_STATUS BlockInSectorRead_PK(byte* data,
                                                             byte sector_address,
                                                             byte block_in_sector_address,
                                                             byte auth_mode,
                                                             byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite")]
        public static extern DL_STATUS BlockInSectorWrite(byte* data,
                                                          byte sector_address,
                                                          byte block_in_sector_address,
                                                          byte auth_mode,
                                                          byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite_AKM1")]
        public static extern DL_STATUS BlockInSectorWrite_AKM1(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);


        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite_AKM2")]
        public static extern DL_STATUS BlockInSectorWrite_AKM2(byte* data,
                                                               byte sector_address,
                                                               byte block_in_sector_address,
                                                               byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "BlockInSectorWrite_PK")]
        public static extern DL_STATUS BlockInSectorWrite_PK(byte* data,
                                                             byte sector_address,
                                                             byte block_in_sector_address,
                                                             byte auth_mode,
                                                             byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead")]
        public static extern DL_STATUS   ValueBlockRead(int* value,
                                                        byte* value_addr,
                                                        UInt16 block_address,
                                                        byte auth_mode,
                                                        byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead_AKM1")]
        public static extern DL_STATUS ValueBlockRead_AKM1(int* value,
                                                           byte* value_addr,
                                                           UInt16 block_address,
                                                           byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead_AKM2")]
        public static extern DL_STATUS ValueBlockRead_AKM2(int* value,
                                                           byte* value_addr,
                                                           UInt16 block_address,
                                                           byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockRead_PK")]
        public static extern DL_STATUS ValueBlockRead_PK(int* value,
                                                         byte* value_addr,
                                                         UInt16 block_address,
                                                         byte auth_mode,
                                                         byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite")]
        public static extern DL_STATUS ValueBlockWrite( int value,
                                                        byte value_addr,
                                                        UInt16 block_address,
                                                        byte auth_mode,
                                                        byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite_AKM1")]
        public static extern DL_STATUS ValueBlockWrite_AKM1(int value,
                                                        byte value_addr,
                                                        UInt16 block_address,
                                                        byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite_AKM2")]
        public static extern DL_STATUS ValueBlockWrite_AKM2(int value,
                                                        byte value_addr,
                                                        UInt16 block_address,
                                                        byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockWrite_PK")]
        public static extern DL_STATUS ValueBlockWrite_PK(int value,
                                                        byte value_addr,
                                                        UInt16 block_address,
                                                        byte auth_mode,
                                                        byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement")]
        public static extern DL_STATUS  ValueBlockIncrement(int increment_value,
                                                            UInt16 block_address,
                                                            byte auth_mode,
                                                            byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement_AKM1")]
        public static extern DL_STATUS ValueBlockIncrement_AKM1(int increment_value,
                                                                UInt16 block_address,
                                                                byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement_AKM2")]
        public static extern DL_STATUS ValueBlockIncrement_AKM2(int increment_value,
                                                                UInt16 block_address,
                                                                byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockIncrement_PK")]
        public static extern DL_STATUS ValueBlockIncrement_PK(int increment_value,
                                                                UInt16 block_address,
                                                                byte auth_mode,
                                                                byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement")]
        public static extern DL_STATUS ValueBlockDecrement(int increment_value,
                                                           UInt16 block_address,
                                                           byte auth_mode,
                                                             byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement_AKM1")]
        public static extern DL_STATUS ValueBlockDecrement_AKM1(int increment_value,
                                                                UInt16 block_address,
                                                                byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement_AKM2")]
        public static extern DL_STATUS ValueBlockDecrement_AKM2(int increment_value,
                                                                UInt16 block_address,
                                                                byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockDecrement_PK")]
        public static extern DL_STATUS ValueBlockDecrement_PK(int increment_value,
                                                              UInt16 block_address,
                                                              byte auth_mode,
                                                              byte* pk_key);
        
         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead")]
         public static extern   DL_STATUS  ValueBlockInSectorRead(Int32 *value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode,
                                                                  byte key_index);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead_AKM1")]
         public static extern DL_STATUS ValueBlockInSectorRead_AKM1(Int32* value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode);


         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead_AKM2")]
         public static extern DL_STATUS ValueBlockInSectorRead_AKM2(Int32* value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorRead_PK")]
         public static extern DL_STATUS ValueBlockInSectorRead_PK(Int32* value,
                                                                  byte* value_addr,
                                                                  byte sector_address,
                                                                  byte block_in_sector_address,
                                                                  byte auth_mode,
                                                                  byte* pk_key);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite")]
         public static extern DL_STATUS ValueBlockInSectorWrite(Int32 value,
                                                                byte value_addr,            
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode,byte key_index);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite_AKM1")]
         public static extern DL_STATUS ValueBlockInSectorWrite_AKM1(Int32 value,
                                                                byte value_addr,
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite_AKM2")]
         public static extern DL_STATUS ValueBlockInSectorWrite_AKM2(Int32 value,
                                                                byte value_addr,
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorWrite_PK")]
         public static extern DL_STATUS ValueBlockInSectorWrite_PK(Int32 value,
                                                                byte value_addr,
                                                                byte sector_address,
                                                                byte block_in_sector_address,
                                                                byte auth_mode,
                                                                byte* pk_key); 

          [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement")]
          public static extern DL_STATUS  ValueBlockInSectorIncrement(Int32 increment_value,
                                                                      byte sector_address,          
                                                                      byte block_in_sector_address,           
                                                                      byte auth_mode,
                                                                      byte key_index);

          [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement_AKM1")]
          public static extern DL_STATUS ValueBlockInSectorIncrement_AKM1(Int32 increment_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode);

          [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement_AKM2")]
          public static extern DL_STATUS ValueBlockInSectorIncrement_AKM2(Int32 increment_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode);


          [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorIncrement_PK")]
          public static extern DL_STATUS ValueBlockInSectorIncrement_PK(Int32 increment_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode,
                                                                      byte* pk_key);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement")]
          public static extern DL_STATUS  ValueBlockInSectorDecrement(Int32 decrement_value,
                                                                      byte sector_address,
                                                                      byte block_in_sector_address,
                                                                      byte auth_mode,
                                                                      byte key_index);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement_AKM1")]
         public static extern DL_STATUS ValueBlockInSectorDecrement_AKM1(Int32 decrement_value,
                                                                     byte sector_address,
                                                                     byte block_in_sector_address,
                                                                     byte auth_mode);


         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement_AKM2")]
         public static extern DL_STATUS ValueBlockInSectorDecrement_AKM2(Int32 decrement_value,
                                                                     byte sector_address,
                                                                     byte block_in_sector_address,
                                                                     byte auth_mode);


         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "ValueBlockInSectorDecrement_PK")]
         public static extern DL_STATUS ValueBlockInSectorDecrement_PK(Int32 decrement_value,
                                                                     byte sector_address,
                                                                     byte block_in_sector_address,
                                                                     byte auth_mode,
                                                                     byte* pk_key);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite")]
         public static extern DL_STATUS SectorTrailerWrite(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode,
                                         byte key_index);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite_AKM1")]
         public static extern DL_STATUS SectorTrailerWrite_AKM1(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite_AKM2")]
         public static extern DL_STATUS SectorTrailerWrite_AKM2(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode);

         [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SectorTrailerWrite_PK")]
         public static extern DL_STATUS SectorTrailerWrite_PK(byte addressing_mode,
                                         byte address,
                                         byte* new_key_A,
                                         byte block0_access_bits,
                                         byte block1_access_bits,
                                         byte block2_access_bits,
                                         byte sector_trailer_access_bits,
                                         byte sector_trailer_byte9,
                                         byte* new_key_B,
                                         byte auth_mode,
                                         byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard")]
       public static extern DL_STATUS  LinearFormatCard(byte* new_key_A,
                                                        byte blocks_access_bits,
                                                        byte sector_trailers_access_bits,
                                                        byte sector_trailers_byte9,
                                                        byte* new_key_B,
                                                        byte* sectors_formatted,
                                                        byte auth_mode,
                                                        byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard_AKM1")]
        public static extern DL_STATUS LinearFormatCard_AKM1(byte* new_key_A,
                                                         byte blocks_access_bits,
                                                         byte sector_trailers_access_bits,
                                                         byte sector_trailers_byte9,
                                                         byte* new_key_B,
                                                         byte* sectors_formatted,
                                                         byte auth_mode);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard_AKM2")]
        public static extern DL_STATUS LinearFormatCard_AKM2(byte* new_key_A,
                                                         byte blocks_access_bits,
                                                         byte sector_trailers_access_bits,
                                                         byte sector_trailers_byte9,
                                                         byte* new_key_B,
                                                         byte* sectors_formatted,
                                                         byte auth_mode);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinearFormatCard_PK")]
        public static extern DL_STATUS LinearFormatCard_PK(byte* new_key_A,
                                                         byte blocks_access_bits,
                                                         byte sector_trailers_access_bits,
                                                         byte sector_trailers_byte9,
                                                         byte* new_key_B,
                                                         byte* sectors_formatted,
                                                         byte auth_mode,                                        
                                                         byte* pk_key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinRowRead")]
        public static extern DL_STATUS LinRowRead(byte* Data, ushort linRow_address, ushort length, ushort* bytes_returned, byte auth_mode, byte key_index);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "LinRowRead_PK")]
        public static extern DL_STATUS LinRowRead_PK(byte* Data, ushort linRow_address, ushort length, ushort* bytes_returned, byte auth_mode, byte* key);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetReaderSerialDescription")]
        public static extern DL_STATUS GetReaderSerialDescription(byte[] SerialDescription);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "GetBuildNumber")]
        public static extern DL_STATUS GetBuildNumber(byte* build);

    }
}
