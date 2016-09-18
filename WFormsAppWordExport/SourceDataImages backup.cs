using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{

    public static class SourceDataImages
    {


        public class ESSENSES_IMEG
        {
            public String name { get; }
            public int dbId { get; }
            public int[] abstEssences { get; }
            public int flag { get; }
            public String script { get; }
            public ESSENSES_IMEG(int dbID, String name, int flag,String script, int[] abstEssencesIDS)
            {
                this.dbId = dbID;
                this.name = name;
                this.flag = flag;
                this.script = script;
                this.abstEssences = abstEssencesIDS;

            }
        }

        public class FEATURE_IMAGE
        {
            public int[] idAnswers;
            public int idDB = -1;
            public String sQuestion;
            public int typeAnswer;
          
          
            private String isUse = null;
            private String after = null;

            public FEATURE_IMAGE(int idDB,String sQuestion,int typeAnswer,int [] idAnswers,string isUse, string after)
            {
                this.idDB = idDB;
                this.sQuestion = sQuestion;
                this.typeAnswer = typeAnswer;
                this.idAnswers = idAnswers;
                this.isUse = isUse;
                this.after = after;
            }

            public Feature getFeature (Essence es)
            {
                List<Choose_Answer> sAnswers = null;
                if (idAnswers != null)
                {
                    sAnswers= new List<Choose_Answer>();
                    foreach (int idAn in idAnswers)
                    {
                        sAnswers.Add(allChooceAnswer[idAn]);
                    }
                }
                return new Feature(es, idDB, sQuestion, sAnswers,(TYPE_ANSWER) typeAnswer, isUse, after);
            }
        }

        public static ESSENSES_IMEG getEssenceImageByID(int idObject)
        {
            return null;
        }

        public static List<ESSENSES_IMEG> getEssenceImageByFlag(ESSENSE_FLAGS fl)
        {
            return null;
        }

        public static ESSENSES_IMEG[] allImageEssences { get; } = new ESSENSES_IMEG[] { };

        public static Dictionary<int, Choose_Answer> allChooceAnswer = new Dictionary<int, Choose_Answer>();

        public static Dictionary<int, FEATURE_IMAGE> allFeatureImages = new Dictionary<int, FEATURE_IMAGE>();

        public static void init()
        {
          
        }


        public static Essence createByImage(ESSENSES_IMEG image)
        {
           
            List<Essence> abstEssences = null;
            if (image.abstEssences != null)
            {
                abstEssences = new List<Essence>();
                foreach (int abstrImID in image.abstEssences)
                {
                    abstEssences.Add(createByImage(getEssenceById(abstrImID)));
                }
            }

            Essence es=new Essence(image.dbId, image.name, (ESSENSE_FLAGS)image.flag, image.script, null, abstEssences);
            List<Feature> features = new List<Feature>();



            es.features = features;
            return es;

        }



        private static ESSENSES_IMEG getEssenceById(int id)
        {
            foreach (ESSENSES_IMEG im in allImageEssences)
                if (im.dbId == id) return im;
            return null;
        }

        private static Image getFromFile(String idNameIfImage)
        {
            String fileName = "//images/" + idNameIfImage;
            return Image.FromFile(fileName);
        }

    }


}
