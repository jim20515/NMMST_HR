//################################################
//WIT Shared Excel Component----------------Dajubo
//################################################

using System;
using Excel;
using System.IO;
using System.Reflection;
using System.Data;

namespace WIT.Template.Project
{
    /// <summary>
    /// To Manupulate Excel Application as Component
    /// </summary>
    public class WExcel
    {
        #region◎-----//Attributes

        private System.Data.DataTable idt_Table;

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        private string is_ErrMsg;

        /// <summary>
        /// Excel範例檔的完整路徑及名稱，當要存檔的檔名不存時，將依據此檔名複製為新檔
        /// </summary>
        private string is_ExcelTemplateFileName;

        /// <summary>
        /// 開啟的檔案的完整路徑及檔名名稱
        /// </summary>
        private string is_FileName;

        /// <summary>
        /// 開啟的檔案欲開啟的工作表名稱
        /// </summary>
        private string is_SheetName;

        /// <summary>
        /// 開啟檔案的模式
        /// </summary>
        private WExcel.FileMode iwe_Mode;

        /// <summary>
        /// Excel檔讀取的起始列數，將把讀取的資料檔作ColumnName
        /// </summary>
        private int ii_ColStartRowIndex;

        /// <summary>
        /// Excel檔讀取的起始欄位數，將把讀取的資料當作ColumnName
        /// </summary>
        private int ii_ColStartColIndex;

        /// <summary>
        /// Excel檔讀取的欄位數
        /// </summary>
        private int ii_ColCount;

        /// <summary>
        /// 要存成新檔ColumnName陣列
        /// </summary>
        private string[] isa_ColName;

        /// <summary>
        /// Excel檔讀取的起始列數，將把讀取的資料當作Data
        /// </summary>
        private int ii_DataStartRowIndex;

        /// <summary>
        /// Excel檔讀取的起始欄數，將把讀取的資料當作Data
        /// </summary>
        private int ii_DataStartColIndex;

        /// <summary>
        /// 指定要讀取的Excel的資料列數目
        /// </summary>
        private int ii_ReadRowCount;

        #endregion

        #region◎-----//Constructor

        /// <summary>
        /// 建構子，初始化變數
        /// </summary>
        public WExcel()
        {
            is_ExcelTemplateFileName = @"c:\Temp\Template.xls";
            iwe_Mode = WExcel.FileMode.OpenOrCreate;
        }


        #endregion

        #region◎-----//Properties

        /// <summary>
        /// 錯誤訊息屬性
        /// </summary>
        public string ErrorMsg
        {
            get { return is_ErrMsg; }
        }

        /// <summary>
        /// 列資料索引陣列
        /// </summary>
        public string[] this[int RowIndex]
        {
            get
            {

                string[] ls_Values;
                this.uf_GetRow(RowIndex, out ls_Values);
                return ls_Values;
            }
        }

        /// <summary>
        /// 儲存格索引陣列
        /// </summary>
        public string this[int RowIndex, int ColIndex]
        {
            get
            {
                return this.uf_GetItem(RowIndex, ColIndex);
            }
            set
            {
                this.uf_SetItem(RowIndex, ColIndex, value);
            }
        }

        #endregion

        #region◎-----//Enumiration

        /// <summary>
        /// 開啟檔案的模式，Open代表一定要有該檔案的存在，OpenOrCreate代表若沒有該檔案，則創造一個新的檔案
        /// </summary>
        public enum FileMode
        {
            Open, OpenOrCreate
        } ;

        #endregion

        #region◎-----//public function

        public string uf_Open(string as_FileName, string as_SheetName, int ai_ColCount)
        {
            return this.uf_Open(is_ExcelTemplateFileName, iwe_Mode, as_FileName, is_SheetName, ai_ColCount, 0, 0, null, 1, 1, 0);
        }

        public string uf_Open(string as_TemplateFileName, WExcel.FileMode awd_Mode, string as_FileName, string as_SheetName, int ai_ColCount)
        {
            return this.uf_Open(as_TemplateFileName, awd_Mode, as_FileName, is_SheetName, ai_ColCount, 0, 0, null, 1, 1, 0);
        }

        public string uf_Open(string as_FileName, string as_SheetName, int ai_ColCount, int ai_ColStartRowIndex, int ai_ColStartColIndex, string[] asa_ColName)
        {
            return this.uf_Open(is_ExcelTemplateFileName, iwe_Mode, as_FileName, is_SheetName, ai_ColCount, ai_ColStartRowIndex, ai_ColStartColIndex, asa_ColName, 1, 1, 0);
        }

        public string uf_Open(string as_FileName, string as_SheetName, int ai_ColCount, int ai_DataStartRowIndex, int ai_DataStartColIndex, int ai_ReadRowCount)
        {
            return this.uf_Open(is_ExcelTemplateFileName, iwe_Mode, as_FileName, as_SheetName, ai_ColCount, 0, 0, null, ai_DataStartRowIndex, ai_DataStartColIndex, ai_ReadRowCount);
        }

        public string uf_Open(string as_ExcelTemplateFileName, WExcel.FileMode awe_Mode, string as_FileName, string as_SheetName, int ai_ColCount, int ai_ColStartRowIndex, int ai_ColStartColIndex, string[] asa_ColName)
        {
            return this.uf_Open(as_ExcelTemplateFileName, awe_Mode, as_FileName, as_SheetName, ai_ColCount, ai_ColStartRowIndex, ai_ColStartColIndex, asa_ColName, 1, 1, 0);
        }

        public string uf_Open(string as_ExcelTemplateFileName, WExcel.FileMode awe_Mode, string as_FileName, string as_SheetName, int ai_ColCount, int ai_ColStartRowIndex, int ai_ColStartColIndex, string[] asa_ColName, int ai_DataStartRowIndex, int ai_DataStartColIndex, int ai_ReadRowCount)
        {
            //設定變數
            is_ExcelTemplateFileName = as_ExcelTemplateFileName;
            iwe_Mode = awe_Mode;
            is_FileName = as_FileName;
            is_SheetName = as_SheetName;
            ii_ColStartRowIndex = ai_ColStartRowIndex;
            ii_ColStartColIndex = ai_ColStartColIndex;
            ii_ColCount = ai_ColCount;
            isa_ColName = asa_ColName;
            ii_DataStartRowIndex = ai_DataStartRowIndex;
            ii_DataStartColIndex = ai_DataStartColIndex;
            ii_ReadRowCount = ai_ReadRowCount;

            //若開檔的模式為Open，且檔案又不存在，則回傳"-1" 
            if (iwe_Mode == WExcel.FileMode.Open && !File.Exists(is_FileName))
            {
                is_ErrMsg = "指定開啟的檔案不存在！";
                return "-1";
            }

            //若檔案不存在，且範例檔也不存在，則回傳"-1"
            if (!File.Exists(is_FileName) && !File.Exists(is_ExcelTemplateFileName))
            {
                is_ErrMsg = "沒有指定複製的檔案！";
                return "-1";
            }

            //檢查各參數的合法性

            //檢查指定各參數的合法性
            if (this.uf_CheckFileStructure(ai_ColCount, ai_ColStartRowIndex, ai_ColStartColIndex, asa_ColName, ai_DataStartRowIndex, ai_DataStartColIndex) != "1")
                return "-1";


            return this.iuf_Open(out idt_Table, is_ExcelTemplateFileName, is_FileName, is_SheetName, ii_ColCount, ii_ColStartRowIndex, ii_ColStartColIndex, isa_ColName, ii_DataStartRowIndex, ii_DataStartColIndex, ii_ReadRowCount);

        }

        public string uf_GetItem(int ai_RowPos, int ai_ColPos)
        {
            string ls_Msg = "";
            string ls_Value = "";
            ls_Msg = this.iuf_GetItem(ref idt_Table, ai_RowPos, ai_ColPos, ref ls_Value);
            if (ls_Msg != "1")
                is_ErrMsg = ls_Msg;
            return ls_Value;
        }

        public string uf_GetItem(string as_Pos)
        {
            int li_RowPos = 0, li_ColPos = 0;

            //先轉換位置
            if (this.uf_ConvertPos(as_Pos, ref li_RowPos, ref li_ColPos) != "1")
                return "-1";

            //平移位置
            li_RowPos -= ii_DataStartRowIndex;
            li_ColPos -= ii_DataStartColIndex;

            return this.uf_GetItem(li_RowPos, li_ColPos);
        }
        public string uf_GetRow(int ai_RowPos, out string[] as_Values)
        {
            string ls_Msg = "";
            ls_Msg = this.iuf_GetRow(ref idt_Table, ai_RowPos, out as_Values);
            if (ls_Msg != "1")
            {
                is_ErrMsg = ls_Msg;
                return "-1";
            }
            return "1";
        }
        public string uf_SetItem(int ai_RowPos, int ai_ColPos, string as_Value)
        {
            string ls_Msg = "";
            ls_Msg = this.iuf_SetItem(ref idt_Table, ai_RowPos, ai_ColPos, as_Value);
            if (ls_Msg != "1")
            {
                is_ErrMsg = ls_Msg;
                return "-1";
            }
            return "1";
        }

        public string uf_SetItem(string as_Pos, string as_Value)
        {
            int li_RowPos = 0, li_ColPos = 0;

            //先轉換位置
            if (this.uf_ConvertPos(as_Pos, ref li_RowPos, ref li_ColPos) != "1")
                return "-1";

            //平移位置
            li_RowPos -= ii_DataStartRowIndex;
            li_ColPos -= ii_DataStartColIndex;

            return this.uf_SetItem(li_RowPos, li_ColPos, as_Value);
        }
        public string uf_InsertRow(string[] as_Values)
        {
            string ls_Msg = "";
            ls_Msg = this.iuf_InsertRow(ref idt_Table, as_Values);
            if (ls_Msg != "1")
            {
                is_ErrMsg = ls_Msg;
                return "-1";
            }
            return "1";
        }

        public string uf_DeleteRow(int ai_RowPos)
        {
            string ls_Msg = "";
            ls_Msg = this.iuf_DeleteRow(ref idt_Table, ai_RowPos);
            if (ls_Msg != "1")
            {
                is_ErrMsg = ls_Msg;
                return "-1";
            }
            return "1";
        }

        public string uf_Save()
        {
            return this.uf_Save(is_ExcelTemplateFileName, is_FileName, is_SheetName, ii_ColStartRowIndex, ii_ColStartColIndex, ii_DataStartRowIndex, ii_DataStartColIndex);
        }
        public string uf_SaveAs(string as_FileName)
        {
            return this.uf_Save(is_ExcelTemplateFileName, as_FileName, is_SheetName, ii_ColStartRowIndex, ii_ColStartColIndex, ii_DataStartRowIndex, ii_DataStartColIndex);
        }
        public string uf_Save(string as_ExcelTemplateFileName, string as_FileName, string as_SheetName, int ai_ColStartRowIndex, int ai_ColStartColIndex, int ai_DataStartRowIndex, int ai_DataStartColIndex)
        {
            is_ExcelTemplateFileName = as_ExcelTemplateFileName;
            is_FileName = as_FileName;
            is_SheetName = as_SheetName;
            ii_ColStartRowIndex = ai_ColStartRowIndex;
            ii_ColStartColIndex = ai_ColStartColIndex;
            ii_DataStartRowIndex = ai_DataStartRowIndex;
            ii_DataStartColIndex = ai_DataStartColIndex;

            return this.iuf_SaveAs(ref idt_Table, is_ExcelTemplateFileName, as_FileName, as_SheetName, ai_ColStartRowIndex, ai_ColStartColIndex, ai_DataStartRowIndex, ai_DataStartColIndex);
        }


        private string uf_ConvertPos(string as_OPos, ref int ai_RowPos, ref int ai_ColPos)
        {
            //檢查合法性
            if (as_OPos.Trim() == "")
            {
                is_ErrMsg = "沒有指定的位置！";
                return "-1";
            }

            if (as_OPos.IndexOf(" ") != -1)
            {
                is_ErrMsg = "指定的位置中不能有SPACE！";
                return "-1";
            }

            if (as_OPos.Length < 2)
            {
                is_ErrMsg = "指定的位置中至少為一個英文字母以及一個數字！";
                return "-1";
            }

            if (!this.uf_CheckChar(as_OPos.Substring(0, 1)))
            {
                is_ErrMsg = "指定的第一個位置應為一個英文字母！";
                return "-1";
            }

            //宣告變數

            int li_Pos = 0;
            int li_Count = 0;
            int li_NumIndex = 0;

            try
            {
                //取得英文字母的字串
                for (int li_counter = 0; li_counter < as_OPos.Length; li_counter++)
                {
                    li_NumIndex = li_counter;
                    if (!this.uf_CheckChar(as_OPos.Substring(li_counter, 1)))
                        break;
                }

                if (as_OPos.Substring(0, li_NumIndex).Length < 1 || as_OPos.Substring(0, li_NumIndex).Length > 2)
                {
                    ai_ColPos = 0;
                    ai_RowPos = 0;
                    is_ErrMsg = "英文字母最大為IV！";
                    return "-1";
                }

                if (as_OPos.Substring(0, li_NumIndex).Length == 1)
                {
                    this.uf_CharPos(as_OPos.Substring(0, 1), ref ai_ColPos);
                }

                if (as_OPos.Substring(0, li_NumIndex).Length == 2)
                {
                    this.uf_CharPos(as_OPos.Substring(0, 1), ref li_Pos);
                    li_Count = li_Pos;
                    this.uf_CharPos(as_OPos.Substring(1, 1), ref li_Pos);
                    ai_ColPos = 26 * li_Count + li_Pos;
                }

                //取得數字部份對應的位置
                ai_RowPos = Convert.ToInt32(as_OPos.Substring(li_NumIndex, (as_OPos.Length - li_NumIndex)));

                return "1";
            }
            catch (Exception e)
            {
                is_ErrMsg = "轉換位置發生錯誤，原因為：" + e.Message;
                return "-1";
            }
        }

        private void uf_CharPos(string as_Temp, ref int ai_Pos)
        {
            if (as_Temp == "a" || as_Temp == "A") ai_Pos = 1;
            else if (as_Temp == "b" || as_Temp == "B") ai_Pos = 2;
            else if (as_Temp == "c" || as_Temp == "C") ai_Pos = 3;
            else if (as_Temp == "d" || as_Temp == "D") ai_Pos = 4;
            else if (as_Temp == "e" || as_Temp == "E") ai_Pos = 5;
            else if (as_Temp == "f" || as_Temp == "F") ai_Pos = 6;
            else if (as_Temp == "g" || as_Temp == "G") ai_Pos = 7;
            else if (as_Temp == "h" || as_Temp == "H") ai_Pos = 8;
            else if (as_Temp == "i" || as_Temp == "I") ai_Pos = 9;
            else if (as_Temp == "j" || as_Temp == "J") ai_Pos = 10;
            else if (as_Temp == "k" || as_Temp == "K") ai_Pos = 11;
            else if (as_Temp == "l" || as_Temp == "L") ai_Pos = 12;
            else if (as_Temp == "m" || as_Temp == "M") ai_Pos = 13;
            else if (as_Temp == "n" || as_Temp == "N") ai_Pos = 14;
            else if (as_Temp == "o" || as_Temp == "O") ai_Pos = 15;
            else if (as_Temp == "p" || as_Temp == "P") ai_Pos = 16;
            else if (as_Temp == "q" || as_Temp == "Q") ai_Pos = 17;
            else if (as_Temp == "r" || as_Temp == "R") ai_Pos = 18;
            else if (as_Temp == "s" || as_Temp == "S") ai_Pos = 19;
            else if (as_Temp == "t" || as_Temp == "T") ai_Pos = 20;
            else if (as_Temp == "u" || as_Temp == "U") ai_Pos = 21;
            else if (as_Temp == "v" || as_Temp == "V") ai_Pos = 22;
            else if (as_Temp == "w" || as_Temp == "W") ai_Pos = 23;
            else if (as_Temp == "x" || as_Temp == "X") ai_Pos = 24;
            else if (as_Temp == "y" || as_Temp == "Y") ai_Pos = 25;
            else if (as_Temp == "z" || as_Temp == "Z") ai_Pos = 26;

        }

        private bool uf_CheckChar(string as_Temp)
        {
            if (as_Temp == "a" || as_Temp == "A") return true;
            if (as_Temp == "b" || as_Temp == "B") return true;
            if (as_Temp == "c" || as_Temp == "C") return true;
            if (as_Temp == "d" || as_Temp == "D") return true;
            if (as_Temp == "e" || as_Temp == "E") return true;
            if (as_Temp == "f" || as_Temp == "F") return true;
            if (as_Temp == "g" || as_Temp == "G") return true;
            if (as_Temp == "h" || as_Temp == "H") return true;
            if (as_Temp == "i" || as_Temp == "I") return true;
            if (as_Temp == "j" || as_Temp == "J") return true;
            if (as_Temp == "k" || as_Temp == "K") return true;
            if (as_Temp == "l" || as_Temp == "L") return true;
            if (as_Temp == "m" || as_Temp == "M") return true;
            if (as_Temp == "n" || as_Temp == "N") return true;
            if (as_Temp == "o" || as_Temp == "O") return true;
            if (as_Temp == "p" || as_Temp == "P") return true;
            if (as_Temp == "q" || as_Temp == "Q") return true;
            if (as_Temp == "r" || as_Temp == "R") return true;
            if (as_Temp == "s" || as_Temp == "S") return true;
            if (as_Temp == "t" || as_Temp == "T") return true;
            if (as_Temp == "u" || as_Temp == "U") return true;
            if (as_Temp == "v" || as_Temp == "V") return true;
            if (as_Temp == "w" || as_Temp == "W") return true;
            if (as_Temp == "x" || as_Temp == "X") return true;
            if (as_Temp == "y" || as_Temp == "Y") return true;
            if (as_Temp == "z" || as_Temp == "Z") return true;
            return false;
        }

        private string uf_CheckFileStructure(int ai_ColCount, int ai_ColStartRowIndex, int ai_ColStartColIndex, string[] asa_ColName, int ai_DataStartRowIndex, int ai_DataStartColIndex)
        {
            //@@-----檢查欄位設定的合法性-----@@

            //欄位總數必須大於等於1
            if (ai_ColCount < 1)
            {
                is_ErrMsg = "至少要有一個欄位！";
                return "-1";
            }

            //若ai_ColStartRowIndex == 0，表示使用者開啟的Excel不指定欄位
            if (ai_ColStartRowIndex < 0)
            {
                is_ErrMsg = "欄位的起始列必須大於等於0！";
                return "-1";
            }


            //若ai_ColStartColIndex == 0，表示使用者開啟的Excel不指定欄位
            if (ai_ColStartColIndex < 0)
            {
                is_ErrMsg = "欄位的起始欄位數必須大於等於0！";
                return "-1";
            }

            //使用者有指定Excel欄位起始列數，則必須同時指定起始欄位數
            if ((ai_ColStartRowIndex > 0 && ai_ColStartColIndex == 0) || (ai_ColStartRowIndex == 0 && ai_ColStartColIndex > 0))
            {
                is_ErrMsg = "設定欄位必須設定起始列數以及起始欄位數！";
                return "-1";
            }

            //若有指定欄位名稱，則欄位名稱總數要等於欄位總數
            if (asa_ColName != null)
            {
                if (asa_ColName.Length != ai_ColCount)
                {
                    is_ErrMsg = "欄位名稱總數要與欄位總數相等！";
                    return "-1";
                }
            }

            //@@------檢查資料列的合法性-----@@

            if (ai_DataStartRowIndex < 1)
            {
                is_ErrMsg = "資料的起始列必須大於等於1！";
                return "-1";
            }

            if (ai_DataStartColIndex < 1)
            {
                is_ErrMsg = "資料的起始欄必須大於等於1！";
                return "-1";
            }

            return "1";

        }


        #endregion

        #region◎-----//private function

        private string iuf_Open(out System.Data.DataTable adt_Table, string as_ExcelTemplateFileName, string as_FileName, string as_SheetName, int ai_ColCount, int ai_ColStartRowIndex, int ai_ColStartColIndex, string[] asa_ColName, int ai_DataStartRowIndex, int ai_DataStartColIndex, int ai_ReadRowCount)
        {
            //若是要存檔的檔案跟要複製的檔案均不存在，則回傳錯誤訊息
            if (!File.Exists(as_FileName) && !File.Exists(as_ExcelTemplateFileName))
            {
                adt_Table = null;
                return "存檔的檔案跟要複製的檔案均不存在！";
            }

            //若要存檔的檔案不存在，則從範例檔複製一份並命名為存檔的檔名
            if (!File.Exists(as_FileName))
            {
                try
                {
                    FileInfo fi = new FileInfo(as_ExcelTemplateFileName);
                    fi.CopyTo(as_FileName, true);
                }
                catch (Exception e)
                {
                    adt_Table = null;
                    return "複製範例檔發生錯誤，原因為：" + e.Message;
                }
            }

            //創造idt_Table ;
            adt_Table = new System.Data.DataTable();

            //創造Column
            if (this.iuf_CreateColumn(ref adt_Table, as_FileName, as_SheetName, ai_ColCount, ai_ColStartRowIndex, ai_ColStartColIndex, asa_ColName) != "1")
            {
                adt_Table = null;
                return "-1";
            }

            //創造資料
            if (File.Exists(as_FileName) && ai_ReadRowCount != -1)
            {
                if (this.iuf_CreateRowData(ref adt_Table, as_FileName, as_SheetName, ai_ColCount, ai_DataStartRowIndex, ai_DataStartColIndex, ai_ReadRowCount) != "1")
                {
                    adt_Table = null;
                    return "-1";
                }
            }

            return "1";
        }

        private string iuf_CreateColumn(ref System.Data.DataTable adt_Table, string as_FileName, string as_SheetName, int ai_ColCount, int ai_ColStartRowIndex, int ai_ColStartColIndex, string[] asa_ColName)
        {
            string ls_Msg = "";

            //檢查欲讀取的欄位數是否大於0
            if (ai_ColCount < 1) return "指定設定的欄位總數必須大於0";

            //利用Excel設定欄位名稱
            if (File.Exists(as_FileName) && ai_ColStartRowIndex > 0 && ai_ColStartColIndex > 0)
            {
                Excel.Application lExcel_App = new Excel.ApplicationClass();
                Excel.Workbook lExcel_WBook;
                Excel.Worksheet lExcel_WSheet;
                ls_Msg = this.iuf_CallExcel(out lExcel_App, out lExcel_WBook, out lExcel_WSheet, as_FileName, as_SheetName);
                //創造Excel檔案成功，利用asa_ColName創造欄位名稱
                if (ls_Msg == "1")
                {
                    try
                    {
                        for (int li_counter = 0; li_counter < ai_ColCount; li_counter++)
                            adt_Table.Columns.Add(new DataColumn(((Excel.Range)lExcel_WSheet.Cells[ai_ColStartRowIndex, ai_ColStartColIndex + li_counter]).Value2.ToString().Trim(), Type.GetType("System.String")));
                        return this.iuf_ReleaseResource(ref lExcel_App, ref lExcel_WBook, ref lExcel_WSheet);
                    }
                    catch (Exception e)
                    {
                        ls_Msg = this.iuf_ReleaseResource(ref lExcel_App, ref lExcel_WBook, ref lExcel_WSheet);
                        if (ls_Msg != "1")
                            return ls_Msg;
                        return "設定欄位名稱發生錯誤，原因為：" + e.Message;
                    }

                }
            }

            //利用asa_ColName設定欄位名稱
            if (asa_ColName != null && asa_ColName.Length == ai_ColCount)
            {
                try
                {
                    for (int li_counter = 0; li_counter < asa_ColName.Length; li_counter++)
                        adt_Table.Columns.Add(new DataColumn(asa_ColName[li_counter], Type.GetType("System.String")));
                }
                catch (Exception e)
                {
                    return "設定指定的欄位名稱發生錯誤，原因為：" + e.Message;

                }
                return "1";
            }

            //設定欄位名稱為預設的值
            try
            {
                for (int li_counter = 0; li_counter < ai_ColCount; li_counter++)
                    adt_Table.Columns.Add(new DataColumn("Column_" + Convert.ToString(li_counter + 1), Type.GetType("System.String")));
                return "1";
            }
            catch (Exception e)
            {
                return "設定指定的欄位名稱發生錯誤，原因為：" + e.Message;
            }



        }

        private string iuf_CreateRowData(ref System.Data.DataTable adt_Table, string as_FileName, string as_SheetName, int ai_ColCount, int ai_DataStartRowIndex, int ai_DataStartColIndex, int ai_ReadRowCount)
        {
            if (!File.Exists(as_FileName) || ai_DataStartRowIndex < 1 || ai_DataStartColIndex < 1 || ai_ColCount < 1)
                return "設定資料失敗，指定設定資料必須指定存在的檔案，資料讀取的起始列數及起始欄位數大於0，讀取的欄位數大於0！";

            //宣告變數
            string ls_Msg = "";
            bool lb_GoRead = false;
            DataRow ldr_Temp;

            Excel.Application lExcel_App = new Excel.ApplicationClass();
            Excel.Workbook lExcel_WBook;
            Excel.Worksheet lExcel_WSheet;

            //開啟Excel檔
            ls_Msg = this.iuf_CallExcel(out lExcel_App, out lExcel_WBook, out lExcel_WSheet, as_FileName, as_SheetName);
            if (ls_Msg != "1")
                return ls_Msg;

            try
            {
                for (int li_counter = 0; li_counter < 65536; li_counter++)
                {
                    lb_GoRead = false;

                    ldr_Temp = adt_Table.NewRow();

                    for (int li_counter2 = 0; li_counter2 < ai_ColCount; li_counter2++)
                    {
                        if (((Excel.Range)lExcel_WSheet.Cells[ai_DataStartRowIndex + li_counter, ai_DataStartColIndex + li_counter2]).Value2 == null)
                        {
                            lb_GoRead = (lb_GoRead || false);
                            ldr_Temp[li_counter2] = "";
                        }
                        else
                        {
                            lb_GoRead = (lb_GoRead || true);
                            ldr_Temp[li_counter2] = ((Excel.Range)lExcel_WSheet.Cells[ai_DataStartRowIndex + li_counter, ai_DataStartColIndex + li_counter2]).Value2.ToString().Trim();
                        }
                    }

                    //若ai_ReadRowCount設定為0，則當讀取到的列資料均為null時停止，否則讀取到ai_ReadRowCount的筆數為止
                    if ((!lb_GoRead && ai_ReadRowCount == 0) || (ai_ReadRowCount != 0 && ai_ReadRowCount == li_counter))
                        break;

                    adt_Table.Rows.Add(ldr_Temp);
                }

                return this.iuf_ReleaseResource(ref lExcel_App, ref lExcel_WBook, ref lExcel_WSheet);
            }
            catch (Exception e)
            {
                ls_Msg = this.iuf_ReleaseResource(ref lExcel_App, ref lExcel_WBook, ref lExcel_WSheet);
                if (ls_Msg != "1")
                    return ls_Msg;
                return "開啟指定的檔案或活頁簿進行資料讀取發生錯誤，原因為：" + e.Message;
            }
        }

        private string iuf_GetRow(ref System.Data.DataTable adt_Table, int ai_RowPos, out string[] as_Values)
        {
            if (ai_RowPos < 0)
            {
                as_Values = null;
                return "讀取資料的列數最小值為0！";
            }

            try
            {
                as_Values = new string[adt_Table.Columns.Count];
                for (int li_counter = 0; li_counter < adt_Table.Columns.Count; li_counter++)
                {
                    as_Values[li_counter] = adt_Table.Rows[ai_RowPos][li_counter].ToString();
                }
                return "1";
            }
            catch (Exception e)
            {
                as_Values = null;
                return "取出資料發生錯誤，原因為：" + e.Message;
            }

        }

        private string iuf_GetItem(ref System.Data.DataTable adt_Table, int ai_RowPos, int ai_ColPos, ref string as_Value)
        {
            if (ai_RowPos < 0 || ai_ColPos < 0)
            {
                as_Value = "<ERROR>";
                return "讀取資料的列數最小值為0，欄位數最小值為0！";
            }

            try
            {
                as_Value = adt_Table.Rows[ai_RowPos][ai_ColPos].ToString();
                return "1";
            }
            catch (Exception e)
            {
                as_Value = "<ERROR>";
                return "讀取資料發生錯誤，原因為：" + e.Message;
            }

        }

        private string iuf_SetItem(ref System.Data.DataTable adt_Table, int ai_RowPos, int ai_ColPos, string as_Value)
        {
            if (ai_RowPos < 0 || ai_ColPos < 0)
                return "設定資料的列數最小值為0，欄位數最小值為0！";

            try
            {
                idt_Table.Rows[ai_RowPos][ai_ColPos] = as_Value;
                return "1";
            }
            catch (Exception e)
            {
                return "設定資料的發生錯誤，原因為：" + e.Message;
            }

        }

        private string iuf_InsertRow(ref System.Data.DataTable adt_Table, string[] as_Values)
        {
            try
            {
                DataRow ldr_Temp = adt_Table.NewRow();
                for (int li_counter = 0; li_counter < as_Values.Length; li_counter++)
                {
                    ldr_Temp[li_counter] = as_Values[li_counter];
                }
                adt_Table.Rows.Add(ldr_Temp);
                return "1";
            }
            catch (Exception e)
            {
                return "新增資料發生錯誤，原因為：" + e.Message;
            }
        }
        private string iuf_DeleteRow(ref System.Data.DataTable adt_Table, int ai_RowPos)
        {
            try
            {
                adt_Table.Rows.RemoveAt(ai_RowPos);
                return "1";
            }
            catch (Exception e)
            {
                return "刪除整筆資料發生錯誤，原因為：" + e.Message;
            }
        }
        private string iuf_SaveAs(ref System.Data.DataTable adt_Table, string as_ExcelTemplateFileName, string as_FileName, string as_SheetName, int ai_ColStartRowIndex, int ai_ColStartColIndex, int ai_DataStartRowIndex, int ai_DataStartColIndex)
        {
            //若是要存檔的檔案跟要複製的檔案均不存在，則回傳錯誤訊息
            if (!File.Exists(as_FileName) && !File.Exists(as_ExcelTemplateFileName))
                return "存檔的檔案跟要複製的檔案均不存在！";

            //若要存檔的檔案不存在，則從範例檔複製一份並命名為存檔的檔名
            if (!File.Exists(as_FileName))
            {
                try
                {
                    FileInfo fi = new FileInfo(as_ExcelTemplateFileName);
                    fi.CopyTo(as_FileName, true);
                }
                catch (Exception e)
                {
                    return "複製範例檔發生錯誤，原因為：" + e.Message;
                }
            }

            //宣告變數
            string ls_Msg = "";
            Excel.Application lExcel_App;
            Excel.Workbook lExcel_WBook;
            Excel.Worksheet lExcel_WSheet;

            //設定Excel檔
            ls_Msg = this.iuf_CallExcel(out lExcel_App, out lExcel_WBook, out lExcel_WSheet, as_FileName, as_SheetName);
            if (ls_Msg != "1")
                return ls_Msg;

            try
            {
                //設定column
                if (ai_ColStartRowIndex != 0 && ai_ColStartColIndex != 0)
                {
                    for (int li_counter = 0; li_counter < idt_Table.Columns.Count; li_counter++)
                        lExcel_WSheet.Rows.Cells[ai_ColStartRowIndex, ai_ColStartColIndex + li_counter] = idt_Table.Columns[li_counter].ColumnName;
                }

                //設定data
                if (idt_Table.Rows.Count != 0)
                {
                    for (int li_counter = 0; li_counter < idt_Table.Rows.Count; li_counter++)
                    {
                        for (int li_counter2 = 0; li_counter2 < idt_Table.Columns.Count; li_counter2++)
                            lExcel_WSheet.Rows.Cells[ai_DataStartRowIndex + li_counter, ai_DataStartColIndex + li_counter2] = idt_Table.Rows[li_counter][li_counter2].ToString().Trim();
                    }
                }

                lExcel_WBook.Save();

                return this.iuf_ReleaseResource(ref lExcel_App, ref lExcel_WBook, ref lExcel_WSheet);
            }
            catch (Exception e)
            {
                ls_Msg = this.iuf_ReleaseResource(ref lExcel_App, ref lExcel_WBook, ref lExcel_WSheet);
                if (ls_Msg != "1")
                    return ls_Msg;
                return "開啟指定的檔案或活頁簿進行資料讀取發生錯誤，原因為：" + e.Message;
            }

        }

        private string iuf_CallExcel(out Excel.Application ae_App, out Excel.Workbook ae_WBook, out Excel.Worksheet ae_WSheet, string as_FileName, string as_SheetName)
        {
            //			//檢查是否有Excel檔存在，以及檔名是否以.xsl結尾
            //			if( ! File.Exists(as_FileName) || as_FileName.IndexOf(".xls") == -1 ) 
            //			{
            //				ae_App = null ;
            //				ae_WBook = null ;
            //				ae_WSheet = null ;
            //				return "無法開啟指定的Excel檔" ;
            //			}

            //宣告變數
            object lo_Miss = Missing.Value;

            //建立ExcelApplication，並開啟指定的Excel檔案
            ae_App = new Excel.ApplicationClass();
            try
            {
                ae_WBook = ae_App.Workbooks.Open(as_FileName, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, lo_Miss, null, null);
            }
            catch (Exception e)
            {
                ae_WSheet = null;
                ae_WBook = null;
                ae_App.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ae_App);
                ae_App = null;
                GC.Collect();
                return "開啟檔案" + as_FileName + "發生錯誤，原因為：" + e.Message;
            }

            //			//檢查Excel檔的第一個工作表是否與欲開啟的名稱相同
            //			if( ((Excel.Worksheet)ae_WBook.Worksheets.get_Item( 1 )).Name != as_SheetName ) 
            //			{
            //				ae_WSheet = null ;
            //				ae_WBook.Close( lo_Miss , lo_Miss , lo_Miss ) ; 
            //				System.Runtime.InteropServices.Marshal.ReleaseComObject( ae_WBook ) ;
            //				ae_WBook = null ;
            //				ae_App.Quit() ;
            //				System.Runtime.InteropServices.Marshal.ReleaseComObject( ae_App ) ;
            //				ae_App = null ;
            //				GC.Collect() ;
            //				return "開啟的Excel的第一個工作表必須與指定的工作表名相同！" ;
            //			}

            //取得工作表
            try
            {
                ae_WSheet = (Excel.Worksheet)ae_WBook.Worksheets[as_SheetName];
            }
            catch (Exception e)
            {
                ae_WSheet = null;
                ae_WBook.Close(lo_Miss, lo_Miss, lo_Miss);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ae_WBook);
                ae_WBook = null;
                ae_App.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ae_App);
                ae_App = null;
                GC.Collect();
                return "開啟檔案發生錯誤，原因為：" + e.Message;
            }

            return "1";
        }
        private string iuf_ReleaseResource(ref Excel.Application ae_App, ref Excel.Workbook ae_WBook, ref Excel.Worksheet ae_WSheet)
        {
            //宣告變數
            object lo_Miss = Missing.Value;

            try
            {
                ae_WBook.Close(lo_Miss, lo_Miss, lo_Miss);
                ae_WSheet = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ae_WBook);
                ae_WBook = null;
                ae_App.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ae_App);
                ae_App = null;
                GC.Collect();
                return "1";
            }
            catch (Exception e)
            {
                is_ErrMsg = "釋放Excel資源發生錯誤，原因為：" + e.Message;
                return "-1";
            }
        }

        #endregion
    }
}
