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
        STRING, NUMBER, CHOOSE, TRUE_FALSE, MULTI_CHOSE, DATE,
        /* ссылки на обьекты события*/
        LIST_IDS_OF_ESSENCE
    };

    // вопросы описывающие участников
    /* форма вопроса, описывает сущность вопроса, из чего она состоит*/
    [Serializable()]
    public class Feature : ISerializable
    {
        public int idDB { get; private set; }
        //вопрос: как он звучит 
        public String sQuestion { get; private set; }
        //тип ответа (вопроса) 
        public TYPE_ANSWER typeAnswer { get; private set; }
        //выборы ответа если тип ответа CHOOSE
        public List <Chooce_Answer> sAnswers { get; private set; }
        //автор ответа
        public String sAuthor {  get; private set;  }
        //ответ на вопрос
        public Answer answer;
        //спрашивать вопрос?  
        private SoftwareSctipt sIsUsable=null;
        //что делает после принятого ответа
        private SoftwareSctipt sAfter=null;

        //отвечен
        private bool _isAnswered = false;

        public bool isAnswered { get { return _isAnswered && isUsable(); } }

        public Feature(int id,String sQuestion, List<Chooce_Answer> sAnswers, TYPE_ANSWER answerType, String isUse, String after)
        {
            set(id, sQuestion, sAnswers,  answerType,  isUse,  after);
        }

        public void set(int id,String sQuestion, List<Chooce_Answer> sAnswers, TYPE_ANSWER answerType, String isUse, String after)
        {
            this.idDB = id;
            this.sQuestion = sQuestion;
            this.sAnswers = sAnswers;
            this.typeAnswer = answerType;
            if (isUse!=null&&isUse.Length>0)
                this.sIsUsable = new SoftwareSctipt(isUse, SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL);
            if (after != null && after.Length > 0)
                this.sAfter = new SoftwareSctipt(after, SoftwareSctipt.SCRIPT_TYPE.VOID);
        }

        protected Feature(SerializationInfo info, StreamingContext context)
        {
            idDB = info.GetInt32("id");
            sQuestion = info.GetString("sQuestion");
            typeAnswer = (TYPE_ANSWER)(int)info.GetInt32("typeAnswer");
            _isAnswered = (bool)info.GetBoolean("isAnswered");
            sAnswers = (List<Chooce_Answer>)info.GetValue("sAnswers", typeof(List<Chooce_Answer>));
            sAuthor = info.GetString("AnswerAuthor");
            answer = (Answer)info.GetValue("Answer", typeof(Answer));
            sIsUsable = new SoftwareSctipt(info.GetString("isUsable"),SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL);
            sAfter = new SoftwareSctipt(info.GetString("after"),SoftwareSctipt.SCRIPT_TYPE.VOID);

        }

        public void setAnswer (Answer answer,String sAuthor)
        {
            this.answer = answer;
            this.sAuthor = sAuthor;
        }

        public bool isUsable()
        {
            if (sIsUsable != null)
                return this.sIsUsable.runBool();
            else return true;
        }

        public void runAfter()
        {
            if (sAfter != null) sAfter.run();
        }

        public void resetAns()
        {
            _isAnswered = false;
            answer.sAnswer = null;
            answer.oAnswer = null;
            sAuthor = "";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("sQuestion", sQuestion);
            info.AddValue("typeAnswer", (int)typeAnswer);
            info.AddValue("AnswerAuthor", sAuthor);
            info.AddValue("Answer", answer);
            info.AddValue("isAnswered", isAnswered);
            info.AddValue("sAnswers", sAnswers);
            info.AddValue("isUsable", sIsUsable.script);
            info.AddValue("after", sAfter.script);
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

    } 

    [Serializable]
    public struct Chooce_Answer
    {
        public String sName;
        public String sExport { get { return (_sExport == null) ? sName : _sExport; }
            set { _sExport = value; } }

        public Image image;

        private String _sExport;

    }


}
