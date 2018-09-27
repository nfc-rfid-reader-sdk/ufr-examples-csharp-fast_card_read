using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using uFrAdvance;

namespace C_sharp_Fast_Card_Read
{
    using DL_STATUS = System.UInt32;

    public partial class FastCardForm : Form
    {

        DL_STATUS status;
        string formattedTime;
        byte GlobalCardType;

        public FastCardForm()
        {
            InitializeComponent();
        }

        const byte MIFARE_AUTHENT1A = 0x60,
                    MIFARE_AUTHENT1B = 0x61;

        //DLOGIC CARD TYPE
        const byte DL_MIFARE_ULTRALIGHT = 0x01,
                   DL_MIFARE_ULTRALIGHT_EV1_11 = 0x02,
                   DL_MIFARE_ULTRALIGHT_EV1_21 = 0x03,
                   DL_MIFARE_ULTRALIGHT_C = 0x04,
                   DL_NTAG_203 = 0x05,
                   DL_NTAG_210 = 0x06,
                   DL_NTAG_212 = 0x07,
                   DL_NTAG_213 = 0x08,
                   DL_NTAG_215 = 0x09,
                   DL_NTAG_216 = 0x0A,
                   DL_MIFARE_MINI = 0x20,
                   DL_MIFARE_CLASSIC_1K = 0x21,
                   DL_MIFARE_CLASSIC_4K = 0x22,
                   DL_MIFARE_PLUS_S_2K = 0x23,
                   DL_MIFARE_PLUS_S_4K = 0x24,
                   DL_MIFARE_PLUS_X_2K = 0x25,
                   DL_MIFARE_PLUS_X_4K = 0x26,
                   DL_MIFARE_DESFIRE = 0x27,
                   DL_MIFARE_DESFIRE_EV1_2K = 0x28,
                   DL_MIFARE_DESFIRE_EV1_4K = 0x29,
                   DL_MIFARE_DESFIRE_EV1_8K = 0x2A;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.d-logic.net/nfc-rfid-reader-sdk/");
        }

        const byte DL_OK = 0,
                    KEY_INDEX = 0;

        //for result                    
        const byte FRES_OK_LIGHT = 4,
                    FRES_OK_SOUND = 1,
                    FERR_LIGHT = 2,
                    FERR_SOUND = 0;

        // sectors and bytes
        const byte
                   MAX_SECTORS_1k = 16,
                   MAX_SECTORS_4k = 40,

                  USER_PAGES_NTAG_203 = 36,
                  USER_PAGES_NTAG_213 = 36,
                  USER_PAGES_NTAG_215 = 126,
                  USER_PAGES_NTAG_216 = 222,
                  USER_PAGES_ULTRALIGHT = 12,
                  USER_PAGES_ULTRALIGHT_C = 36,
                  USER_PAGES_ULTRALIGHT_EV1_11 = 12;

        const short
                   MAX_BYTES_CLASSIC_1K = 1024,
                   MAX_BYTES_CLASSIC_4k = 4096,
                   MAX_BYTES_NTAG_203 = 144,
                   MAX_BYTES_NTAG_213 = 144,
                   MAX_BYTES_NTAG_215 = 504,
                   MAX_BYTES_NTAG_216 = 888,

                   MAX_BYTES_ULTRALIGHT = 48,
                   MAX_BYTES_ULTRALIGHT_C = 144,
                   MAX_BYTES_ULTRALIGHT_EV1_11 = 48,
                   TOTAL_PAGES_NTAG_203 = 42,
                   TOTAL_PAGES_NTAG_213 = 45,
                   TOTAL_PAGES_NTAG_215 = 135,
                   TOTAL_PAGES_NTAG_216 = 226,
                   TOTAL_PAGES_ULTRALIGHT = 16,
                   TOTAL_PAGES_ULTRALIGHT_C = 44,
                   TOTAL_PAGES_ULTRALIGHT_EV1_11 = 16;



        private int MaxSectors(byte bCardType)
        {
            short usMaxSectors = 0;
            switch (bCardType)
            {
                case DL_MIFARE_CLASSIC_1K:
                    usMaxSectors = MAX_SECTORS_1k;
                    break;
            }

            return usMaxSectors;
        }

        private int BytesPerBlock(byte bCardType)
        {
            short usBytes = 0;
            switch (bCardType)
            {
                case DL_MIFARE_ULTRALIGHT:
                DL_MIFARE_ULTRALIGHT_C:
                DL_MIFARE_ULTRALIGHT_EV1_1:
                DL_NTAG_203:
                DL_NTAG_213:
                DL_NTAG_215:
                    usBytes = 4;
                    break;
                case DL_MIFARE_CLASSIC_1K:
                DL_MIFARE_CLASSIC_4K:
                DL_MIFARE_PLUS_S_4K:
                    usBytes = 16;
                    break;
            }
            return usBytes;
        }

        private int MaxBytes(byte bCardType)
        {
            short usMaxBytes = 0;
            switch (bCardType)
            {
                case DL_NTAG_203:
                    usMaxBytes = MAX_BYTES_NTAG_203;
                    break;
                case DL_MIFARE_ULTRALIGHT:
                    usMaxBytes = MAX_BYTES_ULTRALIGHT;
                    break;
                case DL_MIFARE_ULTRALIGHT_C:
                    usMaxBytes = MAX_BYTES_ULTRALIGHT_C;
                    break;
                case DL_MIFARE_CLASSIC_1K:
                    usMaxBytes = MAX_BYTES_CLASSIC_1K;
                    break;
                case DL_MIFARE_CLASSIC_4K:
                case DL_MIFARE_PLUS_S_4K:
                    usMaxBytes = MAX_BYTES_CLASSIC_4k;
                    break;
            }

            return usMaxBytes;
        }

        private int MaxBlocks(byte bCardType)
        {
            short usBlocks = 0;
            switch (bCardType)
            {
                case DL_MIFARE_ULTRALIGHT:
                DL_MIFARE_ULTRALIGHT_EV1_11:
                    usBlocks = TOTAL_PAGES_ULTRALIGHT;
                    break;

                case DL_MIFARE_ULTRALIGHT_C:
                    usBlocks = TOTAL_PAGES_ULTRALIGHT_C;
                    break;

                case DL_NTAG_203:
                    usBlocks = TOTAL_PAGES_NTAG_203;
                    break;

                case DL_NTAG_213:
                    usBlocks = TOTAL_PAGES_NTAG_213;
                    break;

                case DL_NTAG_215:
                    usBlocks = TOTAL_PAGES_NTAG_215;
                    break;

                case DL_NTAG_216:
                    usBlocks = TOTAL_PAGES_NTAG_216;
                    break;

                case DL_MIFARE_CLASSIC_1K:
                    usBlocks = 64;
                    break;

                case DL_MIFARE_CLASSIC_4K:
                DL_MIFARE_PLUS_S_4K:
                    usBlocks = ((MAX_SECTORS_1k * 2) * 4) + ((MAX_SECTORS_1k - 8) * 16);
                    break;
            }
            return usBlocks;
        }

        string GetDlTypeName(byte dl_type_code)
        {
            string s;

            switch (dl_type_code)
            {
                case DL_MIFARE_ULTRALIGHT:
                    s = "DL_MIFARE_ULTRALIGHT";
                    break;
                case DL_MIFARE_ULTRALIGHT_EV1_11:
                    s = "DL_MIFARE_ULTRALIGHT_EV1_11";
                    break;
                case DL_MIFARE_ULTRALIGHT_EV1_21:
                    s = "DL_MIFARE_ULTRALIGHT_EV1_21";
                    break;
                case DL_MIFARE_ULTRALIGHT_C:
                    s = "DL_MIFARE_ULTRALIGHT_C";
                    break;
                case DL_NTAG_203:
                    s = "DL_NTAG_203";
                    break;
                case DL_NTAG_210:
                    s = "DL_NTAG_210";
                    break;
                case DL_NTAG_212:
                    s = "DL_NTAG_212";
                    break;
                case DL_NTAG_213:
                    s = "DL_NTAG_213";
                    break;
                case DL_NTAG_215:
                    s = "DL_NTAG_215";
                    break;
                case DL_NTAG_216:
                    s = "DL_NTAG_216";
                    break;

                case DL_MIFARE_MINI:
                    s = "DL_MIFARE_MINI";
                    break;
                case DL_MIFARE_CLASSIC_1K:
                    s = "DL_MIFARE_CLASSIC_1K";
                    break;
                case DL_MIFARE_CLASSIC_4K:
                    s = "DL_MIFARE_CLASSIC_4K";
                    break;

                case DL_MIFARE_DESFIRE:
                    s = "DL_MIFARE_DESFIRE";
                    break;
                case DL_MIFARE_DESFIRE_EV1_2K:
                    s = "DL_MIFARE_DESFIRE_EV1_2K";
                    break;
                case DL_MIFARE_DESFIRE_EV1_4K:
                    s = "DL_MIFARE_DESFIRE_EV1_4K";
                    break;
                case DL_MIFARE_DESFIRE_EV1_8K:
                    s = "DL_MIFARE_DESFIRE_EV1_8K";
                    break;


                default:
                    s = "UNSUPPORTED CARD";
                    break;
            }



            return s;
        }

        private int MaxTotalBytes(byte bCardType)
        {
            int result = 0;
            switch (bCardType)
            {
                case DL_NTAG_203:
                    result = MAX_BYTES_NTAG_203;
                    break;
                case DL_NTAG_213:
                    result = MAX_BYTES_NTAG_213;
                    break;

                case DL_NTAG_215:
                    result = MAX_BYTES_NTAG_215;
                    break;

                case DL_NTAG_216:
                    result = MAX_BYTES_NTAG_216;
                    break;
                case DL_MIFARE_ULTRALIGHT:
                    result = MAX_BYTES_ULTRALIGHT;
                    break;
                case DL_MIFARE_ULTRALIGHT_C:
                    result = MAX_BYTES_ULTRALIGHT_C;
                    break;
                case DL_MIFARE_CLASSIC_1K:
                    result = MAX_BYTES_CLASSIC_1K;
                    break;
                case DL_MIFARE_CLASSIC_4K:
                DL_MIFARE_PLUS_S_4K:
                    result = MAX_BYTES_CLASSIC_4k;
                    break;
            }
            return result;
        }

        string card_info = "";
        string log_name = "";


        


        private void bOpenReader_Click(object sender, EventArgs e)
        {
            tReaderInfo.Clear();
            unsafe
            {
                byte bHWVerMajor = 0;
                byte bHWVerMinor = 0;
                byte bFWVerMajor = 0;
                byte bFWVerMinor = 0;
                byte build_number = 0;
                byte[] serial_description = new byte[8];


                status = uFCoder.ReaderOpen();
                if (status == DL_OK)
                {

                    uFCoder.ReaderUISignal(1, 1);
                }

                uFCoder.GetReaderHardwareVersion(&bHWVerMajor, &bHWVerMinor);

                uFCoder.GetReaderFirmwareVersion(&bFWVerMajor, &bFWVerMinor);

                uFCoder.GetBuildNumber(&build_number);

                uFCoder.GetReaderSerialDescription(serial_description);

                tReaderInfo.AppendText("Reader serial: " + Encoding.ASCII.GetString(serial_description) + " | " + "Hardware version: " + bHWVerMajor + "." + bHWVerMinor + " | " + "Firmware version: " + bFWVerMajor + "." + bFWVerMinor + "." + build_number);

            }

        }

        private void bCardInfo_Click(object sender, EventArgs e)
        {

            tCardInfo.Clear();
            byte bCardType = 0;
            byte[] bCardUID = new byte[9];
            byte bUidSize = 0;
            String sBuffer = null;

            log_name = "";

            unsafe
            {
                card_info = "";

                fixed (byte* uid = bCardUID)
                    status = uFCoder.GetCardIdEx(&bCardType, uid, &bUidSize);

                status = uFCoder.GetDlogicCardType(&bCardType);
                if (status != 0)
                    tInfo.Text = "Error has occured, Error code: " + "0x" + status.ToString("X2");

                

                for (byte bCounter = 0; bCounter < bUidSize; bCounter++)
                {
                    sBuffer += bCardUID[bCounter].ToString("X2");
                }

                card_info += "Card type: " + "0x" + bCardType.ToString("X2") + " - " + GetDlTypeName(bCardType) + "\n";

                card_info += "Card UID: " + sBuffer + " --- UID Length: " + bUidSize + " Bytes\n";

                card_info += MaxBlocks(bCardType) + " blocks," + BytesPerBlock(bCardType) + " bytes per block, total " + MaxBytes(bCardType) + " Bytes\n";

                tCardInfo.Text = card_info;

                log_name += sBuffer;

                if (bCardType != GlobalCardType)
                {
                    GlobalCardType = bCardType;
                }

            }

            if (MaxBlocks(bCardType) == 0)
            {
                bReadCard.Enabled = false;
            }
            else
            {
                bReadCard.Enabled = true;
            }
            
        }
        
        private void bReadCard_Click(object sender, EventArgs e)
        {
            tInfo.Clear();
            ASCIIBox.Clear();

            byte bDLCardType;

            unsafe
            {
                uFCoder.GetDlogicCardType(&bDLCardType);
            }

            int uiDataLength = MaxBytes(bDLCardType);
            byte[] baReadData = new byte[uiDataLength];
            byte[] DataOut = new byte[uiDataLength];
            ushort uiLinearAddress = 0;
            int uiBytesRet = 0;
            DL_STATUS status;
           
            var time = DateTime.Now;

            formattedTime = time.ToString("HH:mm:ss yyyy-MM-dd");

            unsafe
            {
                byte[] KeyPK = new byte[6] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

                fixed (byte* PData = baReadData)
                {
                    fixed (byte* ptr_key = KeyPK)
                        status = uFCoder.LinRowRead_PK(PData, uiLinearAddress, (ushort)uiDataLength, (ushort*)&uiBytesRet, MIFARE_AUTHENT1A, ptr_key);

                }
                if (status == DL_OK)
                {

                    tInfo.Text = "Info generated on: " + formattedTime + "\n" + card_info;

                    tInfo.AppendText("\r\n" + "Dec  Hex   Bytes                                            " + "\r\n");
                    
                    ASCIIBox.AppendText("\r\nDec  Hex\r\n");

                    string ascii_string = "";

                    for (int i = 0; i < baReadData.Length; i++)
                    {
                        string data = "";
                        string line = "";
                        
                        DataOut[i] = baReadData[i];
                        
                        if (i == 0)
                        {
                            tInfo.AppendText("00   000   ");
                           
                        }
                        else if (i != 0 && i % 16 == 0)
                        {
                            line = "";
                            line += "\r\n" + (i / 16).ToString("D2") + "   " + (i / 16).ToString("X3") + "   ";
                            tInfo.AppendText(line);
                            
                        }
                        
                        data += baReadData[i].ToString("X2") + " ";

                        tInfo.Text += data;
                        if (baReadData[i] < 20 || baReadData[i]>128)
                        { 

                            ascii_string += ".";
                        }
                        else
                        {
                            ascii_string += (char)baReadData[i];
                        }

                    }
                    
                    for (int k = 0; k < baReadData.Length; k++)
                    {
                        
                        string line = "";

                        if ((k != 0) && (k % 16 == 0))
                        {

                            ASCIIBox.Text += "\r\n";
                            line = "";
                            line += "\r\n" + (k / 16).ToString("D2") + "   " + (k / 16).ToString("X3") + "   ";
                            ASCIIBox.AppendText(line);

                        }
                        if (k == 0)
                        {
                            ASCIIBox.AppendText("00   000   ");

                        }

                        ASCIIBox.Text += ascii_string[k];
                        
                    }

                    uFCoder.ReaderUISignal(1, 1);

                }
                else
                {

                    uFCoder.ReaderUISignal(1, 0);

                    tInfo.Text = card_info;

                    tInfo.AppendText("\n An error has occured, Error code: " + "0x" + status.ToString("X2"));

                }



                var time_log = DateTime.Now;
                string format_time;
                format_time = time.ToString("HH-mm-ss yyyy-MM-dd");

                log_name = log_name + "_" + format_time;

                if (saveMFD.Checked)
                {
                    log_name = log_name + ".mfd";

                    File.WriteAllText(log_name, Encoding.ASCII.GetString(DataOut));

                    log_name = log_name.Remove(log_name.Length - 4);

                }
                if (saveTXT.Checked)
                {
                    log_name = log_name + ".txt";
                    File.WriteAllText(log_name, "\r\n--------------------------HEX----------------------------\r\n"+
                                      tInfo.Text+ "\r\n--------------------------ASCII----------------------------\r\n"+ ASCIIBox.Text);
                    
                    log_name = log_name.Substring(log_name.Length - 4);

                }

                log_name = "";

                bReadCard.Enabled = false;

            }

        }
    }
}
