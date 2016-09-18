/**
 Copyright 2016 Andrey Kuzubov

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License. 
*/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace WFormsAppWordExport.DataStructures
{
   
    [Serializable()]
    public enum TYPE_ANSWER
    {
        STRING=0, NUMBER=1, CHOOSE=2, TRUE_FALSE=3, MULTI_CHOSE=4, DATE=5,
        /* ссылки на обьекты события*/
        LIST_IDS_OF_ESSENCE=6
    };

    // вопросы описывающие участников
    /* форма вопроса, описывает сущность вопроса, из чего она состоит*/
    [Serializable()]
    public class Feature : ISerializable
    {
        public Essence parentEssence { get; private set; } = null;
        public int idDB { get; private set; }
        //вопрос: как он звучит 
        public String sQuestion { get; private set; }
        //тип ответа (вопроса) 
        public TYPE_ANSWER typeAnswer { get; private set; }
        private List<Choose_Answer> _sAnswers;
        //выборы ответа если тип ответа CHOOSE
        public List<Choose_Answer> sAnswers
        {
            get
            {
                if (_sAnswers == null) _sAnswers = new List<Choose_Answer>();
                return _sAnswers;
            }
            private set
            {
                _sAnswers = value;
            }

        } 
        //автор ответа
        public String sAuthor {  get; private set;  }
        //ответ на вопрос
        public Answer answer { get; private set; }
        //спрашивать вопрос?  
        public SoftwareSctipt sIsUsable=null;
        //что делает после принятого ответа
        public SoftwareSctipt sAfter=null;

        //отвечен
        private bool _isAnswered = false;

        public bool isAnswered { get { return _isAnswered && isUsable(); } }

        public Feature(Essence es, int id,String sQuestion, List<Choose_Answer> sAnswers, TYPE_ANSWER answerType, String isUse, String after)
        {
            set(es,id, sQuestion, sAnswers,  answerType,  isUse,  after);
        }

        public void set(Essence es,int id,String sQuestion, List<Choose_Answer> sAnswers, TYPE_ANSWER answerType, String isUse, String after)
        {
            this.parentEssence = es;
            this.idDB = id;
            this.sQuestion = sQuestion;
            this.sAnswers = sAnswers;
            this.typeAnswer = answerType;
            if (isUse!=null&&isUse.Length>0)
                this.sIsUsable = new SoftwareSctipt(isUse, SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL, parentEssence, this);
            if (after != null && after.Length > 0)
                this.sAfter = new SoftwareSctipt(after, SoftwareSctipt.SCRIPT_TYPE.VOID, parentEssence, this);
        }

        protected Feature(SerializationInfo info, StreamingContext context)
        {
            parentEssence = (Essence)info.GetValue("p", typeof(Essence));
            idDB = info.GetInt32("i");
            sQuestion = info.GetString("q");
            typeAnswer = (TYPE_ANSWER)(int)info.GetInt32("t");
            _isAnswered = (bool)info.GetBoolean("ad");
            sAnswers = (List<Choose_Answer>)info.GetValue("as", typeof(List<Choose_Answer>));
            sAuthor = info.GetString("aa");
            answer = (Answer)info.GetValue("a", typeof(Answer));
            sIsUsable = new SoftwareSctipt(info.GetString("u"),SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL, parentEssence, this);
            sAfter = new SoftwareSctipt(info.GetString("af"),SoftwareSctipt.SCRIPT_TYPE.VOID, parentEssence, this);
        }

        public void setAnswer(Essence eAnswer)
        {
            if (eAnswer != null)
                setAnswer(eAnswer, eAnswer.sName);
            else
            {
                resetAns();
            }
        }
        public void setAnswer(String sAnswer)
        {
            if (sAnswer != null)
                setAnswer(sAnswer);
            else
            {
                resetAns();
            }
        }

        public void setAnswer(DateSaver dateAnswer)
        {
            if (dateAnswer != null)
            {
                setAnswer(dateAnswer, dateAnswer.getStringDate());
            }
            else
            {
                resetAns();
            }
        }
        public void setAnswer(int iAnswer)
        {
            setAnswer(iAnswer,null);
        }
        public void setAnswer(bool bAnswer)
        {
            setAnswer(bAnswer, (bAnswer)?"да":"нет");
        }



        public void setAnswer (Answer answer,String sAuthor)
        {
            this.answer = answer;
            this.sAuthor = sAuthor;
            _isAnswered = true;
            runAfter();
        }

        protected void setAnswer(Object oAnswer, String strAnswer)
        {
            setAnswer(new Answer(oAnswer, strAnswer), ProjectDataHelper.sUser);
        }

        public bool isUsable()
        {
            if (sIsUsable != null)
                return this.sIsUsable.runBool(true);
            else return true;
        }

        public void runAfter()
        {
            if (sAfter != null) sAfter.run();
        }

        public void resetAns()
        {
            _isAnswered = false;
            answer = null;
            sAuthor = "";
            runAfter();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("p", parentEssence);
            info.AddValue("q", sQuestion);
            info.AddValue("t", (int)typeAnswer);
            info.AddValue("aa", sAuthor);
            info.AddValue("a", answer);
            info.AddValue("ad", isAnswered);
            info.AddValue("as", sAnswers);
            info.AddValue("u",(sIsUsable!=null)?sIsUsable.script:null);
            info.AddValue("af",(sAfter!=null)?sAfter.script:null);
            info.AddValue("i", idDB);
        }

        public string toString()
        {
            return answer.sAnswer;
        }

      
    }

    [Serializable]
    public class DateSaver
    {
        [NonSerialized]
        static CultureInfo ruCulture = CultureInfo.CreateSpecificCulture("ru-RU");

        public enum DATE_FORMAT { YEAR,YEAR_MONTH, YEAR_MONTH_DAY, YEAR_MONTH_DAY_TIME, MONTH_DAY_TIME,TIME }
        public DATE_FORMAT format;

        public DateTime date;
    
        public String getStringDate()
        {
            String s = "";
            switch (format)
            {
                case DATE_FORMAT.YEAR:
                    s =""+ date.Year;
                    break;
                case DATE_FORMAT.YEAR_MONTH:
                    s = date.ToString("y", ruCulture);
                    break;
                case DATE_FORMAT.YEAR_MONTH_DAY:
                    s = date.ToString("f", ruCulture);
                    break;
                case DATE_FORMAT.YEAR_MONTH_DAY_TIME:
                    //s = date.ToString("f", ruCulture);
                    s = date.ToString("g", ruCulture);
                    break;
                case DATE_FORMAT.MONTH_DAY_TIME:
                    //s = date.ToString("f", ruCulture);
                    s = date.ToString("m t", ruCulture);
                    break;
                case DATE_FORMAT.TIME:
                    s = date.ToString("t", ruCulture);
                    //s = date.ToShortTimeString();
                    break;
            }
            return s;
        }


    }

    [Serializable]
    public class Answer
    {
        private String _sAnswer;

        public Object oAnswer;

        public Essence eAnswer { set { oAnswer = value; } get { return (Essence)oAnswer; } }

        public String sAnswer { set { _sAnswer = value; }  get { return ((_sAnswer== null)? oAnswer.ToString():_sAnswer); } }

        public DateSaver dateAnswer { set { oAnswer = value; } get { return (DateSaver)oAnswer; } }
     
        public int intAnswer { set { oAnswer = value; } get { return (int)oAnswer; } }

        public Answer(Object oAnswer):this(oAnswer,null)
        {
        }

        public Answer(Object oAnswer,String sAnswer)
        {
            this.oAnswer = oAnswer;
            this.sAnswer = sAnswer;
        }

        protected Answer(SerializationInfo info, StreamingContext context)
        {
            oAnswer = info.GetValue("oAnswer",typeof(Object));
            sAnswer = info.GetString("sAnswer");
         //   lChosen_Answers = (List<Choose_Answer>)info.GetValue("chosenDB", typeof(List<Choose_Answer>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("oAnswer", oAnswer);
            info.AddValue("sAnswer", sAnswer);
       //     info.AddValue("chosenDB", lChosen_Answers);
        }

        public bool chech([MettodVariants(typeof(Answer), "variantsChooseAnswers") ]int idChooseAnswer)
        {
            return idChooseAnswer == intAnswer;
        }
        #region use in scrips

        public static AutocompleteMenuNS.AutocompleteItem[] variantsChooseAnswers()
        {
            List<AutocompleteMenuNS.MulticolumnAutocompleteItem> items = new List<AutocompleteMenuNS.MulticolumnAutocompleteItem>();
            List<DBTemplatesHelper.DBAnswer> dbAs = DBTemplatesHelper.DBAnswer.getAnswers();

            foreach (DBTemplatesHelper.DBAnswer dbA in dbAs)
            {
                items.Add(new AutocompleteMenuNS.MulticolumnAutocompleteItem(new string[] { "" + dbA.id, dbA.sName }, "" + dbA.id));
            }
            return items.ToArray();
        }

        #endregion

    }

    [Serializable]
    public class Choose_Answer
    {
        public int id = -1;
        public int pos = 0;
        public String sName = null;
        private String _sExport = null;
        public Image image = null;
        public int idObject = -1;

        public String sExport { get { return (_sExport == null) ? sName : _sExport; }
            set { _sExport = value; } }

        public Choose_Answer() { }

        public Choose_Answer(String sName)
        {
            this.sName = sName;
        }

        public Choose_Answer(int id,String name,int pos,Image image,int idObject)
        {
            this.id = id;
            this.sName = name;
            this.pos = pos;
            this.image = image;
            this.idObject = idObject;
        }

        public Choose_Answer(DBTemplatesHelper.DBAnswer dad):base()
        {
            id = dad.id;
            sName = dad.sName;
            pos = dad.pos;
            sExport = dad.sExport;
            image = dad.image;
            idObject = dad.idObject;
        }

        protected Choose_Answer(SerializationInfo info, StreamingContext context)
        {
            id = info.GetInt32("id");
            sName = info.GetString("sName");
            pos = info.GetInt32("pos");
            sExport = info.GetString("sExport");
            image =(Image) info.GetValue("image",typeof(Image));
            idObject = info.GetInt32("idObj");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("sName", sName);
            info.AddValue("pos",pos);
            info.AddValue("sExport", sExport);
            info.AddValue("image", image);
            info.AddValue("idObj", idObject);
        }


    }

}
