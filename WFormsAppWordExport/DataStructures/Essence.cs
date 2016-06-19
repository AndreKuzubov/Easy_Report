using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace WFormsAppWordExport.DataStructures
{
    [Serializable()]
    public enum ESSENSE_FLAGS
    {
        /** может добавляться больше 1 раза */
        MULTIPLE = 2,
        /** изначально в есть в корне*/
        BASIS = 1,
        /** нельзя добавить в явном ввиде, (не будет работать с 2 первыми флагами)*/
        ABSTRACT = 4
    }

    public delegate void DelegVoid();

    [Serializable()]
    public class Essence : TreeNode, ISerializable
    {
        public DelegVoid afterWishUpdateQuestions;

        public String sName { get; private set; }

        public SoftwareSctipt script { get; private set; }

        public ESSENSE_FLAGS flags { get; private set; }

        public List<Essence> abstrEssences { get; private set; }=new List<Essence>();

        public List<Feature> features { get; private set; } = new List<Feature>();

        public Essence(String sName,  ESSENSE_FLAGS flags,String script,List<Feature>features, List<Essence> AbstrEssences ) : base(sName)
        {
            this.flags = flags;
            this.sName = sName;
            if (abstrEssences!=null)
                this.abstrEssences = abstrEssences;
            this.script = new SoftwareSctipt(script);
            if (features!=null)
                this.features = features;
            createContextMenu();
        }

        protected Essence(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            sName = (String)info.GetValue("sName", typeof(String));
            flags = (ESSENSE_FLAGS)info.GetValue("esFlags",typeof(ESSENSE_FLAGS));
            abstrEssences = (List<Essence>)info.GetValue("abst", typeof(List<Essence>));
            features = (List<Feature>)info.GetValue("features", typeof(List<Feature>));
            createContextMenu();
        }
       
        private void createContextMenu()
        {
           /* if (baseQuestion == (QUESTION_GROUP.AUTO))
                createContextMenuAuto();
            else if (baseQuestion == (QUESTION_GROUP.MAN))
                createContextMenuMan();*/
        }

        private void createContextMenuAuto()
        {
            /*8MenuItem addDriver = new MenuItem("Добавить водителя");
            MenuItem addPassanger = new MenuItem("Добавить пассажира");
            MenuItem addPedenstrian = new MenuItem("Добавить сбитого пешехода этим тс");
            MenuItem addAuto = new MenuItem("Добавить тс");
            MenuItem del = new MenuItem("Удалить");
            ContextMenu m;
            addDriver.Click += delegate
            {
                Essence es = new Essence("Водитель", QUESTION_GROUP.MAN, true);
                es.getQuestionGroup(QUESTION_GROUP.MAN)[0].setAnswer((Object)0, Program.sUser);
                this.Nodes.Add(es);
            };
            addPassanger.Click += delegate
            {
                Essence es = new Essence("Пассажир", QUESTION_GROUP.MAN, true);
                es.getQuestionGroup(QUESTION_GROUP.MAN)[0].setAnswer((Object)1, Program.sUser);
                this.Nodes.Add(es);
            };
            addPedenstrian.Click += delegate
            {
                Essence es = new Essence("Пешеход", QUESTION_GROUP.MAN, true);
                es.getQuestionGroup(QUESTION_GROUP.MAN)[0].setAnswer((Object)2, Program.sUser);
                this.Nodes.Add(es);
            };
            addAuto.Click += delegate
            {
                Essence es = new Essence("Транспортное средство", QUESTION_GROUP.AUTO, true);
                this.Nodes.Add(es);
            };
            del.Click += delegate
            {
                this.Remove();
            };

            if (isDelFromTree)
                m = new ContextMenu(new MenuItem[] { addDriver, addPassanger, addPedenstrian, addAuto, del });
            else
                m = new ContextMenu(new MenuItem[] { addDriver, addPassanger, addPedenstrian, addAuto });

            this.ContextMenu = m;*/
        }

        private void createContextMenuMan()
        {
           /* MenuItem addSchool = new MenuItem("Добавить сведения о школе");
            MenuItem del = new MenuItem("Удалить");
            ContextMenu m = new ContextMenu(new MenuItem[] { addSchool, del });
            addSchool.Click += delegate
            {
                addChild("Школа", QUESTION_GROUP.SCHOOL);
            };
            del.Click += delegate
            {
                Remove();
            };
            ContextMenu = m;*/
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.Serialize(info, context);
            info.AddValue("sName", sName);
            info.AddValue("esFlags", flags);
            info.AddValue("abst", abstrEssences);
            info.AddValue("features", features);
        }
    }
}


