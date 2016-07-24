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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;
using System.ComponentModel;
using System.Data;
using System.Drawing;

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
        private Essence parentEssence=null;
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
        private SoftwareSctipt sIsUsable=null;
        //что делает после принятого ответа
        private SoftwareSctipt sAfter=null;

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
            parentEssence = (Essence)info.GetValue("parentEssence", typeof(Essence));
            idDB = info.GetInt32("id");
            sQuestion = info.GetString("sQuestion");
            typeAnswer = (TYPE_ANSWER)(int)info.GetInt32("typeAnswer");
            _isAnswered = (bool)info.GetBoolean("isAnswered");
            sAnswers = (List<Choose_Answer>)info.GetValue("sAnswers", typeof(List<Choose_Answer>));
            sAuthor = info.GetString("AnswerAuthor");
            answer = (Answer)info.GetValue("Answer", typeof(Answer));
            sIsUsable = new SoftwareSctipt(info.GetString("isUsable"),SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL, parentEssence, this);
            sAfter = new SoftwareSctipt(info.GetString("after"),SoftwareSctipt.SCRIPT_TYPE.VOID, parentEssence, this);
        }

        public void setAnswer (Answer answer,String sAuthor)
        {
            this.answer = answer;
            this.sAuthor = sAuthor;
            _isAnswered = true;
            runAfter();
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
            info.AddValue("parentEssence", parentEssence);
            info.AddValue("sQuestion", sQuestion);
            info.AddValue("typeAnswer", (int)typeAnswer);
            info.AddValue("AnswerAuthor", sAuthor);
            info.AddValue("Answer", answer);
            info.AddValue("isAnswered", isAnswered);
            info.AddValue("sAnswers", sAnswers);
            info.AddValue("isUsable",(sIsUsable!=null)?sIsUsable.script:null);
            info.AddValue("after",(sAfter!=null)?sAfter.script:null);
            info.AddValue("id", idDB);
        }

        public string toString()
        {
            return answer.sAnswer;
        }

      
    }

    [Serializable]
    public struct DateSaver
    {
        public DateTime date;
        public bool isDate;
        public DateTime time;
        public bool isTime;
    }

    [Serializable]
    public class Answer
    {
       // public List<Choose_Answer> lChosen_Answers=new List<Choose_Answer>();

        private String _sAnswer;

        public Object oAnswer;

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
