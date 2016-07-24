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
        private Essence parentEssence=null;
        [NonSerialized]
        public DelegVoid afterWishUpdateQuestions;
        /// <summary>
        /// id of feature which after the !abstract! essence will show 
        /// </summary>
        public int idFeatureAfterShow=-1;

        public int idDb;

        public String sName
        {
            get
            {
                return Name;
            }
            set
            {
                Text = value;
                Name = value;
            }
        }

        public SoftwareSctipt isShowScript { get; private set; }

        public ESSENSE_FLAGS flags { get; private set; }

        public List<Essence> abstrEssences { get; private set; }=new List<Essence>();

        public List<Feature> features { get; private set; } = new List<Feature>();

        public Essence(int id,String sName,  ESSENSE_FLAGS flags,String script,List<Feature>features, List<Essence> AbstrEssences ) : base(sName)
        {
            this.idDb = id;
            this.flags = flags;
            this.sName = sName;
            if (abstrEssences!=null)
                this.abstrEssences = abstrEssences;
            this.isShowScript = new SoftwareSctipt(script,SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL,this);
            if (features!=null)
                this.features = features;
            createContextMenu();
        }

        public Essence([MettodVariants(typeof(ProjectDataHelper), "getEssences")] int idImageObject,string name):this (DBTemplatesHelper.DBObject.get(idImageObject))
        {
            this.sName = name;
        }

        public Essence(DBTemplatesHelper.DBObject dbObject):base(dbObject.name)
        {
            this.sName = dbObject.name;
            this.isShowScript = new SoftwareSctipt(dbObject.script, SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL,this);
            this.flags = (ESSENSE_FLAGS)dbObject.flags;
            this.idDb = dbObject.id;
            DBTemplatesHelper.get().getFeatures(this, this.idDb);

            int[] abstr = ConvertFormat.stringToArray(dbObject.sObjects);
            if (abstr != null)
                foreach (int id in abstr)
                {
                    Essence abstEs = new Essence(DBTemplatesHelper.DBObject.get(id));
                        abstEs.parentEssence = (this.parentEssence!= null)?this.parentEssence:this;
                    this.abstrEssences.Add(abstEs);
                }
            createContextMenu();
        }

        protected Essence(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            idDb = info.GetInt32("id");
            parentEssence = (Essence)info.GetValue("parentEssence", typeof(Essence));
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
            info.AddValue("parentEssence", parentEssence);
            info.AddValue("sName", sName);
            info.AddValue("esFlags", flags);
            info.AddValue("abst", abstrEssences);
            info.AddValue("features", features);
            info.AddValue("id", idDb);
        }

        public List<Feature> getFeatureByImage([MettodVariants (typeof(Essence), "variantsFeatures")] int idFeature)
        {
            List<Feature> fs = new List<Feature>();
            foreach(Feature f in features)
            {
                if (f.idDB == idFeature)
                    fs.Add(f);
            }
            foreach (Essence es in abstrEssences)
            {
                foreach (Feature f in es.features)
                {
                    if (f.idDB == idFeature)
                        fs.Add(f);
                }
            }         

            return fs;
        }
       
        #region use in scrips

        public static AutocompleteMenuNS.AutocompleteItem[] variantsFeatures()
        {
            List<AutocompleteMenuNS.MulticolumnAutocompleteItem> items = new List<AutocompleteMenuNS.MulticolumnAutocompleteItem>();
            List<DBTemplatesHelper.DBFeature> dbFs = DBTemplatesHelper.DBFeature.getFeatures();

            foreach (DBTemplatesHelper.DBFeature dbF in dbFs)
            {
                items.Add(new AutocompleteMenuNS.MulticolumnAutocompleteItem(new string[] { "" + dbF.id, dbF.sQuestion }, "" + dbF.id));
            }
            return items.ToArray();
        }

       

        #endregion
    }
}


