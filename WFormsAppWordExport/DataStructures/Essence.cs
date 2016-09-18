using System;
using System.Collections.Generic;
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
        public Essence parentEssence=null;
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

        private SoftwareSctipt isShowScript;

        public ESSENSE_FLAGS flags { get; private set; }

        public List<Essence> abstrEssences { get; private set; }=new List<Essence>();

        public List<Feature> features { get;  set; } = new List<Feature>();

        public Essence(int id,String sName,  ESSENSE_FLAGS flags,String script,List<Feature>features, List<Essence> AbstrEssences ) : base(sName)
        {
            this.idDb = id;
            this.flags = flags;
            this.sName = sName;
            if (abstrEssences != null)
            {
                this.abstrEssences = abstrEssences;
                foreach (Essence child in abstrEssences)
                {
                    child.parentEssence = this;
                }
            }
            this.isShowScript = new SoftwareSctipt(script,SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL,this);
            if (features != null)
            {
                this.features = features;
            }
             
            createContextMenu();
        }


        public Essence([MettodVariants(typeof(ProjectDataHelper), "getEssences")] int idImageObject,string name)
        {
            Essence es = (SourceDataImages.createByImage(SourceDataImages.getEssenceImageByID(idImageObject)));
            this.idDb = es.idDb;
            this.flags = es.flags;
            this.sName = es.sName;
            if (abstrEssences != null)
            {
                this.abstrEssences = es.abstrEssences;
                foreach (Essence child in abstrEssences)
                {
                    child.parentEssence = this;
                }
            }
            this.isShowScript = new SoftwareSctipt(es.isShowScript.script, SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL, this);
            if (es.features != null)
            {
                this.features = es.features;
                for (int i=0;i<this.features.Count;i++)
                {
                    Feature f = this.features[i];
                    this.features[i] = new Feature(this, f.idDB, f.sQuestion, f.sAnswers, f.typeAnswer,(f.sIsUsable != null) ? f.sIsUsable.script : null, (f.sAfter != null) ? f.sAfter.script : null);
                }
            }

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
            idDb = info.GetInt32("i");
            parentEssence = (Essence)info.GetValue("p", typeof(Essence));
            sName = (String)info.GetValue("n", typeof(String));
            flags = (ESSENSE_FLAGS)info.GetValue("f",typeof(ESSENSE_FLAGS));
            abstrEssences = (List<Essence>)info.GetValue("a", typeof(List<Essence>));
            features = (List<Feature>)info.GetValue("r", typeof(List<Feature>));
            isShowScript = new SoftwareSctipt(info.GetString("s"),SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL,this);
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
            info.AddValue("p", parentEssence);
            info.AddValue("n", sName);
            info.AddValue("f", flags);
            info.AddValue("a", abstrEssences);
            info.AddValue("r", features);
            info.AddValue("i", idDb);
            info.AddValue("s", isShowScript.script);
        }

        public bool hasEssence([MettodVariants(typeof(ProjectDataHelper), "getEssences")] int idEssence)
        {
            return getRootParent().prHasEssence(idEssence);
        }

        private bool prHasEssence([MettodVariants(typeof(ProjectDataHelper), "getEssences")] int idEssence)
        {
            if (idDb == idEssence) return true;
            foreach (Essence es in abstrEssences)
            {
                if (es.prHasEssence(idEssence))
                    return true;
            }
            return false;
        }

        public List<Feature> getFeatureByImage([MettodVariants(typeof(Essence), "variantsFeatures")] int idFeature)
        {
            return getRootParent().prGetFeatureByImage(idFeature);
        }

        private List<Feature> prGetFeatureByImage([MettodVariants (typeof(Essence), "variantsFeatures")] int idFeature)
        {
            List<Feature> fs = new List<Feature>();
            foreach(Feature f in features)
            {
                if (f.idDB == idFeature)
                    fs.Add(f);
            }
            foreach (Essence es in abstrEssences)
            {
                fs.AddRange(es.prGetFeatureByImage(idFeature));
            }         

            return fs;
        }
     
        private Essence getRootParent()
        {
            if (parentEssence == null) return this;
            return parentEssence.getRootParent();
        }
        
        public bool isShow()
        {
            if (parentEssence != null && !parentEssence.isShow())
                return false;
            return isShowScript.runBool(true);
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


