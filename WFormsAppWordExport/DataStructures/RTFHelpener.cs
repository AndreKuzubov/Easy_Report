using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
  
    public class RTFHelpener
    {
        const String SCRIPT = @"(SRIPT";
        public String Rtf;

        public RTFHelpener() { }
        public RTFHelpener(String rtf)
        {
            this.Rtf = rtf;
        }

        #region public methods
        public static String makeMyScript(int idScript)
        {
           return makeProtectedText(SCRIPT + idScript + @")");
        }

        public bool isProtectedTextRtf(int iCharIndexRtf)
        {
            string _rtf = Rtf;
            int iEnd = _rtf.IndexOf(@"\protect0", iCharIndexRtf);
            int iSt2 = _rtf.IndexOf(@"\protect", iCharIndexRtf);
            if (iSt2 != -1 && iEnd != -1 && iSt2 < iEnd) return false;
            int iStart = _rtf.LastIndexOf(@"\protect", iCharIndexRtf);
            int iEn2 = _rtf.LastIndexOf(@"\protect0", iCharIndexRtf);
            if (iStart != -1 && iEn2 != -1 && iStart < iEn2) return false;
            if (iStart != -1 && iEnd != -1 && iStart < iEnd) return true;
            else return false;

        }

        public int getIdSript(int iCharIndex)
        {
            int i = -1;
            int indexRtf = getRtfIndexByTextIndex(iCharIndex);
            if (isProtectedTextRtf(indexRtf))
            {
                int iStart = Rtf.LastIndexOf(@"\protect", indexRtf);
                iStart = Rtf.IndexOf(SCRIPT, iStart) + SCRIPT.Length;
                String s = Rtf.Substring(iStart, Rtf.IndexOf(@")", iStart) - iStart);
                return Int32.Parse(s);
            }

            return -1;
        }

        public void delScript(int idScript)
        {
            String fordel = SCRIPT + idScript + @")";
            int i = Rtf.IndexOf(fordel);
            if (i == -1) return;
            Rtf = Rtf.Remove(i, fordel.Length);
        }

        public int getRtfIndexByTextIndex(int iCharIndex)
        {
            int offcet = 0;
            String _rtf = this.Rtf;
            {
                int d = _rtf.IndexOf("\\uc");
                while (d != -1)
                {
                    _rtf = _rtf.Remove(d, 6);
                    offcet += 6;
                    d = _rtf.IndexOf("\\uc");
                }
            }


            if (_rtf == null || _rtf.Length == 0) return 0;
            int i = 0, k = 0;
            int block = 0; bool sysWord = false, inVisible = false;
            i = _rtf.IndexOf("{\\*\\");
            i = _rtf.IndexOf('}', i) + 1;



            while (k <= iCharIndex && i < _rtf.Length)
            {

                if (_rtf[i] == '\\') sysWord = true;
                if (_rtf[i] == '{') block++;
                if (_rtf[i] == 'v' && _rtf[i - 1] == '\\' && _rtf[i + 1] == ' ') inVisible = true;
                if ((!sysWord) && (block == 0) && (!inVisible)) k++;
                if (_rtf[i] == '0' && _rtf[i - 1] == 'v' && _rtf[i - 2] == '\\') inVisible = false;
                if (_rtf[i] == ' ' || _rtf[i] == '{' || _rtf[i] == '}') sysWord = false;
                if (_rtf[i] == '}') block--;

                i++;
            }
            if (i >= _rtf.Length) i = _rtf.Length - 1;
            return i + 3;

        }


        public void replaceScriptToText(int idScript, String text)
        {
            RichTextBox rtfBox = new RichTextBox();
            rtfBox.Rtf = Rtf;

            String fordel = SCRIPT + idScript + @")";
            int i = rtfBox.Text.IndexOf(fordel);
            if (i == -1) return;
            rtfBox.Text=rtfBox.Text.Remove(i, fordel.Length);
            rtfBox.Text = rtfBox.Text.Insert(i, text);
            Rtf = rtfBox.Rtf;

        }
        #endregion

        #region private methods
        private static String makeProtectedText(string _text)
        {
            StringBuilder _doc = new StringBuilder();
            
            _doc.Append(@"{\rtf1\ansi" + @"\protect " + _text + @"\protect0}");
            return _doc.ToString();

        }

         private int getIdScriptText(int iCharIndexRtf)
        {
            //scriptText - protected  SCRIPT
            int d = 0, e;
            int i = 0;
            do
            {
                d++;
                i = Rtf.IndexOf(SCRIPT, i + 1);
            } while (i != -1 && i < iCharIndexRtf);
            d--;
            return d;
        }
       
        private String decodeASCII(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] > 1000)
                {
                    // byte[] sb=  BitConverter.GetBytes(s[i]-848);
                    int d = s[i] -848;
                    s = s.Replace("" + s[i], @"\lang1049 "+ @"\'" + d.ToString("x2") );
                }
             
            }
            return s;
        }
        #endregion

    }
}
