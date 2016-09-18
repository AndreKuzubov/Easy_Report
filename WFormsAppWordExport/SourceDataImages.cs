
/**
AutoGenereted code by UCTemplateObject.cs

 Copyright 2016 Andrey Kuzubov

Licensed under the Apache License, Version 2.0 (the License);
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an AS IS BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

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
            public ESSENSES_IMEG(int dbID, String name, int flag, String script, int[] abstEssencesIDS)
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

            public FEATURE_IMAGE(int idDB, String sQuestion, int typeAnswer, int[] idAnswers, string isUse, string after)
            {
                this.idDB = idDB;
                this.sQuestion = sQuestion;
                this.typeAnswer = typeAnswer;
                this.idAnswers = idAnswers;
                this.isUse = isUse;
                this.after = after;
            }

            public Feature getFeature(Essence es)
            {
                List<Choose_Answer> sAnswers = null;
                if (idAnswers != null)
                {
                    sAnswers = new List<Choose_Answer>();
                    foreach (int idAn in idAnswers)
                    {
                        sAnswers.Add(allChooceAnswer[idAn]);
                    }
                }
                return new Feature(es, idDB, sQuestion, sAnswers, (TYPE_ANSWER)typeAnswer, isUse, after);
            }
        }

        public static ESSENSES_IMEG[] allImageEssences { get; } = new ESSENSES_IMEG[] { new ESSENSES_IMEG(8, "Вступление", 1, null, new int[] { }), new ESSENSES_IMEG(4, "Общие Сведения", 1, null, new int[] { }), new ESSENSES_IMEG(5, "Сведения о дорожных условиях", 1, null, new int[] { }), new ESSENSES_IMEG(6, "ТС", 2, null, new int[] { 18 }), new ESSENSES_IMEG(18, "Механические ТС", 4, @"if (currEssence.getFeatureByImage(60)[0].answer!=null && 
 currEssence.getFeatureByImage(60)[0].answer.intAnswer==0) return true;
else return false;", new int[] { }), new ESSENSES_IMEG(7, "Участник", 2, null, new int[] { 14, 13, 11, 22, 15 }), new ESSENSES_IMEG(11, "Пострадавший", 4, @"if (currEssence.getFeatureByImage(103)[0].answer != null &&
currEssence.getFeatureByImage(103)[0].answer.intAnswer == 1 )return true;
return false;", new int[] { }), new ESSENSES_IMEG(22, "Водитель", 4, @"if ( currEssence.getFeatureByImage(96)[0].answer!=null && 
currEssence.getFeatureByImage(96)[0].answer.intAnswer == 1 ) return true;
return false;", new int[] { 12 }), new ESSENSES_IMEG(12, "Водитель совершеннолетний", 4, @"if ( currEssence.getFeatureByImage(93)[0].answer== null ) return false;
DateSaver date =currEssence.getFeatureByImage(93)[0].answer.dateAnswer;

if (( DateTime.Today-date.date).TotalDays > 6600) return true;
return false;", new int[] { }), new ESSENSES_IMEG(13, "Пассажир", 4, @"if ( currEssence.getFeatureByImage(96)[0].answer!=null && 
currEssence.getFeatureByImage(96)[0].answer.intAnswer == 3 ) return true;
return false;", new int[] { }), new ESSENSES_IMEG(14, "Пешеход", 4, @"if ( currEssence.getFeatureByImage(96)[0].answer!=null && 
currEssence.getFeatureByImage(96)[0].answer.intAnswer == 2 ) return true;
return false;", new int[] { }), new ESSENSES_IMEG(15, "Несовершеннолетний", 4, @" if ( currEssence.getFeatureByImage(93)[0].answer== null ) return false;
DateSaver date =currEssence.getFeatureByImage(93)[0].answer.dateAnswer;

if (( DateTime.Today-date.date).TotalDays <= 6600) return true;
return false;", new int[] { 19, 20, 21 }), new ESSENSES_IMEG(19, "Несовершеннолетний водитель", 4, @"if ( currEssence.getFeatureByImage(96)[0].answer!=null && 
currEssence.getFeatureByImage(96)[0].answer.intAnswer == 1 ) return true;
return false;", new int[] { }), new ESSENSES_IMEG(20, "Несовершеннолетний пешеход", 4, @"if ( currEssence.getFeatureByImage(96)[0].answer!=null && 
currEssence.getFeatureByImage(96)[0].answer.intAnswer == 2 ) return true;
return false;", new int[] { }), new ESSENSES_IMEG(21, "Несовершеннолетний пассажир", 4, @"if ( currEssence.getFeatureByImage(96)[0].answer!=null && 
currEssence.getFeatureByImage(96)[0].answer.intAnswer == 3 ) return true;
return false;", new int[] { }), new ESSENSES_IMEG(16, "Сведения о школе", 2, null, new int[] { }), new ESSENSES_IMEG(17, "Сведения о прибытии на место ДТП", 1, null, new int[] { }) };

        public static Dictionary<int, FEATURE_IMAGE> allFeatureImages = new Dictionary<int, FEATURE_IMAGE>();

        public static Dictionary<int, Choose_Answer> allChooceAnswer = new Dictionary<int, Choose_Answer>();

        public static void init()
        {
            allChooceAnswer.Add(80, new Choose_Answer(80, "3.1", 0, getImageFromFile("3.1.bmp"), -1));
            allChooceAnswer.Add(1, new Choose_Answer(1, "асфальт", 0, null, -1));
            allChooceAnswer.Add(10, new Choose_Answer(10, "100 м", 0, null, -1));
            allChooceAnswer.Add(17, new Choose_Answer(17, "прямая в плане", 0, null, -1));
            allChooceAnswer.Add(23, new Choose_Answer(23, "мост", 0, null, -1));
            allChooceAnswer.Add(67, new Choose_Answer(67, "2.1", 0, getImageFromFile("2.1.bmp"), -1));
            allChooceAnswer.Add(186, new Choose_Answer(186, "r1.2.1", 0, getImageFromFile("r1.2.1.bmp"), -1));
            allChooceAnswer.Add(222, new Choose_Answer(222, "40 км/ч", 0, null, -1));
            allChooceAnswer.Add(232, new Choose_Answer(232, "1-А", 0, null, -1));
            allChooceAnswer.Add(21, new Choose_Answer(21, "Сухое", 0, null, -1));
            allChooceAnswer.Add(238, new Choose_Answer(238, "обочины нет", 0, null, -1));
            allChooceAnswer.Add(244, new Choose_Answer(244, "Искусственное, включено,исправно", 0, null, -1));
            allChooceAnswer.Add(241, new Choose_Answer(241, "ограждение отсутствует", 0, null, -1));
            allChooceAnswer.Add(252, new Choose_Answer(252, "регулируемое", 0, null, -1));
            allChooceAnswer.Add(254, new Choose_Answer(254, "темное", 0, null, -1));
            allChooceAnswer.Add(257, new Choose_Answer(257, "пробка", 0, null, -1));
            allChooceAnswer.Add(270, new Choose_Answer(270, "1", 0, null, -1));
            allChooceAnswer.Add(306, new Choose_Answer(306, "1", 0, null, -1));
            allChooceAnswer.Add(260, new Choose_Answer(260, "ясно", 0, null, -1));
            allChooceAnswer.Add(267, new Choose_Answer(267, "муниципальная", 0, null, -1));
            allChooceAnswer.Add(318, new Choose_Answer(318, "Механические ТС", 0, null, -1));
            allChooceAnswer.Add(333, new Choose_Answer(333, "мопед", 0, null, -1));
            allChooceAnswer.Add(320, new Choose_Answer(320, "Механические ТС", 0, null, -1));
            allChooceAnswer.Add(344, new Choose_Answer(344, "юр. лицо", 0, null, 7));
            allChooceAnswer.Add(354, new Choose_Answer(354, "Участник", 0, null, 7));
            allChooceAnswer.Add(355, new Choose_Answer(355, "Не учавствовал в ДТП", 0, null, -1));
            allChooceAnswer.Add(359, new Choose_Answer(359, "Сведения о школе", 0, null, 16));
            allChooceAnswer.Add(360, new Choose_Answer(360, "отказался от госпитализации", 0, null, -1));
            allChooceAnswer.Add(363, new Choose_Answer(363, "жилая зона", 0, null, -1));
            allChooceAnswer.Add(381, new Choose_Answer(381, "ручные тормоза", 0, null, -1));
            allChooceAnswer.Add(386, new Choose_Answer(386, "жилая зона", 0, null, -1));
            allChooceAnswer.Add(374, new Choose_Answer(374, "велосипед", 0, null, -1));
            allChooceAnswer.Add(391, new Choose_Answer(391, "темная", 0, null, -1));
            allChooceAnswer.Add(397, new Choose_Answer(397, "не было", 0, null, -1));
            allChooceAnswer.Add(403, new Choose_Answer(403, "в школу", 0, null, -1));
            allChooceAnswer.Add(394, new Choose_Answer(394, "нет", 0, null, -1));
            allChooceAnswer.Add(408, new Choose_Answer(408, "постоянный", 0, null, -1));
            allChooceAnswer.Add(411, new Choose_Answer(411, "100 м.", 0, null, -1));
            allChooceAnswer.Add(416, new Choose_Answer(416, "в школу", 0, null, -1));
            allChooceAnswer.Add(424, new Choose_Answer(424, "100 м.", 0, null, -1));
            allChooceAnswer.Add(430, new Choose_Answer(430, "впереди рядом с водителем", 0, null, -1));
            allChooceAnswer.Add(434, new Choose_Answer(434, "один из родителей", 0, null, -1));
            allChooceAnswer.Add(440, new Choose_Answer(440, "A", 0, null, -1));
            allChooceAnswer.Add(444, new Choose_Answer(444, "пешеходный переход", 0, null, -1));
            allChooceAnswer.Add(449, new Choose_Answer(449, "искусственное, включено, исправно", 0, null, -1));
            allChooceAnswer.Add(453, new Choose_Answer(453, "ТС", 0, null, 6));
            allChooceAnswer.Add(454, new Choose_Answer(454, "Юр. лицо", 0, null, -1));
            allChooceAnswer.Add(421, new Choose_Answer(421, "Разовый", 0, null, -1));
            allChooceAnswer.Add(457, new Choose_Answer(457, "не привлекались", 0, null, -1));
            allChooceAnswer.Add(458, new Choose_Answer(458, "Участник", 0, null, 7));
            allChooceAnswer.Add(459, new Choose_Answer(459, "ТС", 0, null, 6));
            allChooceAnswer.Add(422, new Choose_Answer(422, "постоянный", 1, null, -1));
            allChooceAnswer.Add(455, new Choose_Answer(455, "индивидуальный предприниматель", 1, null, -1));
            allChooceAnswer.Add(450, new Choose_Answer(450, "искусственное, отсутствует", 1, null, -1));
            allChooceAnswer.Add(445, new Choose_Answer(445, "надземный переход", 1, null, -1));
            allChooceAnswer.Add(441, new Choose_Answer(441, "B", 1, null, -1));
            allChooceAnswer.Add(435, new Choose_Answer(435, "родственник", 1, null, -1));
            allChooceAnswer.Add(431, new Choose_Answer(431, "сзади за местом водителя", 1, null, -1));
            allChooceAnswer.Add(425, new Choose_Answer(425, "200 м.", 1, null, -1));
            allChooceAnswer.Add(417, new Choose_Answer(417, "из школы", 1, null, -1));
            allChooceAnswer.Add(412, new Choose_Answer(412, "200 м.", 1, null, -1));
            allChooceAnswer.Add(409, new Choose_Answer(409, "разовый", 1, null, -1));
            allChooceAnswer.Add(395, new Choose_Answer(395, "сьемные", 1, null, -1));
            allChooceAnswer.Add(404, new Choose_Answer(404, "из школы", 1, null, -1));
            allChooceAnswer.Add(398, new Choose_Answer(398, "родители", 1, null, -1));
            allChooceAnswer.Add(392, new Choose_Answer(392, "светлая", 1, null, -1));
            allChooceAnswer.Add(375, new Choose_Answer(375, "самокат", 1, null, -1));
            allChooceAnswer.Add(387, new Choose_Answer(387, "проезжая часть", 1, null, -1));
            allChooceAnswer.Add(382, new Choose_Answer(382, "фары", 1, null, -1));
            allChooceAnswer.Add(364, new Choose_Answer(364, "проезжая часть", 1, null, -1));
            allChooceAnswer.Add(356, new Choose_Answer(356, "водитель", 1, null, -1));
            allChooceAnswer.Add(345, new Choose_Answer(345, "индивидуальный предприниматель ", 1, null, -1));
            allChooceAnswer.Add(321, new Choose_Answer(321, "Немеханические ТС", 1, null, -1));
            allChooceAnswer.Add(334, new Choose_Answer(334, "мотоцикл", 1, null, -1));
            allChooceAnswer.Add(319, new Choose_Answer(319, "Немеханические ТС", 1, null, -1));
            allChooceAnswer.Add(268, new Choose_Answer(268, "частная", 1, null, -1));
            allChooceAnswer.Add(261, new Choose_Answer(261, "пасмурно", 1, null, -1));
            allChooceAnswer.Add(307, new Choose_Answer(307, "2", 1, null, -1));
            allChooceAnswer.Add(271, new Choose_Answer(271, "2", 1, null, -1));
            allChooceAnswer.Add(258, new Choose_Answer(258, "повышенный траффик", 1, null, -1));
            allChooceAnswer.Add(255, new Choose_Answer(255, "светлое", 1, null, -1));
            allChooceAnswer.Add(253, new Choose_Answer(253, "нерегулируемое", 1, null, -1));
            allChooceAnswer.Add(242, new Choose_Answer(242, "автомобильное", 1, null, -1));
            allChooceAnswer.Add(245, new Choose_Answer(245, "Искусственное отсутствует", 1, null, -1));
            allChooceAnswer.Add(239, new Choose_Answer(239, "битая", 1, null, -1));
            allChooceAnswer.Add(22, new Choose_Answer(22, "Мокрое", 1, null, -1));
            allChooceAnswer.Add(233, new Choose_Answer(233, "1-Б", 1, null, -1));
            allChooceAnswer.Add(223, new Choose_Answer(223, "60 км/ч", 1, null, -1));
            allChooceAnswer.Add(187, new Choose_Answer(187, "r1.2.2", 1, getImageFromFile("r1.2.2.bmp"), -1));
            allChooceAnswer.Add(68, new Choose_Answer(68, "2.2", 1, getImageFromFile("2.2.bmp"), -1));
            allChooceAnswer.Add(24, new Choose_Answer(24, "тоннель", 1, null, -1));
            allChooceAnswer.Add(18, new Choose_Answer(18, "есть точные данные", 1, null, -1));
            allChooceAnswer.Add(11, new Choose_Answer(11, "200 м", 1, null, -1));
            allChooceAnswer.Add(2, new Choose_Answer(2, "грунтовка", 1, null, -1));
            allChooceAnswer.Add(81, new Choose_Answer(81, "3.2", 1, getImageFromFile("3.2.bmp"), -1));
            allChooceAnswer.Add(82, new Choose_Answer(82, "3.3", 2, getImageFromFile("3.3.bmp"), -1));
            allChooceAnswer.Add(3, new Choose_Answer(3, "асфальтобетонное", 2, null, -1));
            allChooceAnswer.Add(12, new Choose_Answer(12, "400 м", 2, null, -1));
            allChooceAnswer.Add(19, new Choose_Answer(19, "большой радиус", 2, null, -1));
            allChooceAnswer.Add(25, new Choose_Answer(25, "эстакада", 2, null, -1));
            allChooceAnswer.Add(69, new Choose_Answer(69, "2.3.1", 2, getImageFromFile("2.3.1.bmp"), -1));
            allChooceAnswer.Add(188, new Choose_Answer(188, "r1.3", 2, getImageFromFile("r1.3.bmp"), -1));
            allChooceAnswer.Add(224, new Choose_Answer(224, "90 км/ч", 2, null, -1));
            allChooceAnswer.Add(234, new Choose_Answer(234, "2", 2, null, -1));
            allChooceAnswer.Add(240, new Choose_Answer(240, "асфальт", 2, null, -1));
            allChooceAnswer.Add(246, new Choose_Answer(246, "Искусственное, выключено, исправно ", 2, null, -1));
            allChooceAnswer.Add(243, new Choose_Answer(243, "пешеходное", 2, null, -1));
            allChooceAnswer.Add(256, new Choose_Answer(256, "сумерки", 2, null, -1));
            allChooceAnswer.Add(259, new Choose_Answer(259, "ремонтные работы", 2, null, -1));
            allChooceAnswer.Add(272, new Choose_Answer(272, "3", 2, null, -1));
            allChooceAnswer.Add(308, new Choose_Answer(308, "3", 2, null, -1));
            allChooceAnswer.Add(262, new Choose_Answer(262, "дождь", 2, null, -1));
            allChooceAnswer.Add(269, new Choose_Answer(269, "федеральная", 2, null, -1));
            allChooceAnswer.Add(335, new Choose_Answer(335, "легковая а/м", 2, null, -1));
            allChooceAnswer.Add(346, new Choose_Answer(346, "физ. лицо", 2, null, -1));
            allChooceAnswer.Add(357, new Choose_Answer(357, "пешеход", 2, null, -1));
            allChooceAnswer.Add(365, new Choose_Answer(365, "тротуар", 2, null, -1));
            allChooceAnswer.Add(383, new Choose_Answer(383, "световозражающие элементы", 2, null, -1));
            allChooceAnswer.Add(388, new Choose_Answer(388, "тротуар", 2, null, -1));
            allChooceAnswer.Add(393, new Choose_Answer(393, "комбинированная", 2, null, -1));
            allChooceAnswer.Add(399, new Choose_Answer(399, "родственники", 2, null, -1));
            allChooceAnswer.Add(405, new Choose_Answer(405, "в магазин ", 2, null, -1));
            allChooceAnswer.Add(396, new Choose_Answer(396, "несьемные", 2, null, -1));
            allChooceAnswer.Add(410, new Choose_Answer(410, "школа- дом- школа", 2, null, -1));
            allChooceAnswer.Add(413, new Choose_Answer(413, "400 м.", 2, null, -1));
            allChooceAnswer.Add(418, new Choose_Answer(418, "домой", 2, null, -1));
            allChooceAnswer.Add(426, new Choose_Answer(426, "400 м.", 2, null, -1));
            allChooceAnswer.Add(432, new Choose_Answer(432, "сзади", 2, null, -1));
            allChooceAnswer.Add(436, new Choose_Answer(436, "друг", 2, null, -1));
            allChooceAnswer.Add(442, new Choose_Answer(442, "C", 2, null, -1));
            allChooceAnswer.Add(446, new Choose_Answer(446, "подземный переход", 2, null, -1));
            allChooceAnswer.Add(451, new Choose_Answer(451, "искусственное, выключено, исправно ", 2, null, -1));
            allChooceAnswer.Add(456, new Choose_Answer(456, "физ. лицо", 2, null, -1));
            allChooceAnswer.Add(423, new Choose_Answer(423, "школа-дом-школа", 2, null, -1));
            allChooceAnswer.Add(452, new Choose_Answer(452, "искусственное, включено, неисправно", 3, null, -1));
            allChooceAnswer.Add(447, new Choose_Answer(447, "тротуар", 3, null, -1));
            allChooceAnswer.Add(443, new Choose_Answer(443, "D", 3, null, -1));
            allChooceAnswer.Add(437, new Choose_Answer(437, "знакомый ", 3, null, -1));
            allChooceAnswer.Add(433, new Choose_Answer(433, "на третьем пассажирскои ряду", 3, null, -1));
            allChooceAnswer.Add(427, new Choose_Answer(427, "500 м.", 3, null, -1));
            allChooceAnswer.Add(419, new Choose_Answer(419, "в магазин", 3, null, -1));
            allChooceAnswer.Add(414, new Choose_Answer(414, "500 м.", 3, null, -1));
            allChooceAnswer.Add(406, new Choose_Answer(406, "домой", 3, null, -1));
            allChooceAnswer.Add(400, new Choose_Answer(400, "знакомые ", 3, null, -1));
            allChooceAnswer.Add(389, new Choose_Answer(389, "обочина", 3, null, -1));
            allChooceAnswer.Add(384, new Choose_Answer(384, "зеркала", 3, null, -1));
            allChooceAnswer.Add(366, new Choose_Answer(366, "обочина", 3, null, -1));
            allChooceAnswer.Add(358, new Choose_Answer(358, "пассажир", 3, null, -1));
            allChooceAnswer.Add(336, new Choose_Answer(336, "грузова а/м", 3, null, -1));
            allChooceAnswer.Add(263, new Choose_Answer(263, "снег", 3, null, -1));
            allChooceAnswer.Add(309, new Choose_Answer(309, "4", 3, null, -1));
            allChooceAnswer.Add(273, new Choose_Answer(273, "4", 3, null, -1));
            allChooceAnswer.Add(247, new Choose_Answer(247, "Искусственное, включено, неисправно", 3, null, -1));
            allChooceAnswer.Add(235, new Choose_Answer(235, "3", 3, null, -1));
            allChooceAnswer.Add(225, new Choose_Answer(225, "110 км/ч", 3, null, -1));
            allChooceAnswer.Add(189, new Choose_Answer(189, "r1.4", 3, getImageFromFile("r1.4.bmp"), -1));
            allChooceAnswer.Add(70, new Choose_Answer(70, "2.3.2", 3, getImageFromFile("2.3.2.bmp"), -1));
            allChooceAnswer.Add(26, new Choose_Answer(26, "трубы", 3, null, -1));
            allChooceAnswer.Add(20, new Choose_Answer(20, "малый радиус", 3, null, -1));
            allChooceAnswer.Add(13, new Choose_Answer(13, "500 м", 3, null, -1));
            allChooceAnswer.Add(4, new Choose_Answer(4, "мостовая", 3, null, -1));
            allChooceAnswer.Add(83, new Choose_Answer(83, "3.4", 3, getImageFromFile("3.4.bmp"), -1));
            allChooceAnswer.Add(84, new Choose_Answer(84, "3.5", 4, getImageFromFile("3.5.bmp"), -1));
            allChooceAnswer.Add(5, new Choose_Answer(5, "щебеночные", 4, null, -1));
            allChooceAnswer.Add(14, new Choose_Answer(14, "хорошая", 4, null, -1));
            allChooceAnswer.Add(27, new Choose_Answer(27, "путевод", 4, null, -1));
            allChooceAnswer.Add(71, new Choose_Answer(71, "2.3.3", 4, getImageFromFile("2.3.3.bmp"), -1));
            allChooceAnswer.Add(190, new Choose_Answer(190, "r1.5", 4, getImageFromFile("r1.5.bmp"), -1));
            allChooceAnswer.Add(236, new Choose_Answer(236, "4", 4, null, -1));
            allChooceAnswer.Add(274, new Choose_Answer(274, "5", 4, null, -1));
            allChooceAnswer.Add(310, new Choose_Answer(310, "5", 4, null, -1));
            allChooceAnswer.Add(264, new Choose_Answer(264, "гололед", 4, null, -1));
            allChooceAnswer.Add(337, new Choose_Answer(337, "грузовая а/м с прицепом", 4, null, -1));
            allChooceAnswer.Add(367, new Choose_Answer(367, "пешеходный переход", 4, null, -1));
            allChooceAnswer.Add(385, new Choose_Answer(385, "звонок", 4, null, -1));
            allChooceAnswer.Add(390, new Choose_Answer(390, "пешеходный переход", 4, null, -1));
            allChooceAnswer.Add(401, new Choose_Answer(401, "педагоги", 4, null, -1));
            allChooceAnswer.Add(407, new Choose_Answer(407, "гулял", 4, null, -1));
            allChooceAnswer.Add(415, new Choose_Answer(415, "1000 м.", 4, null, -1));
            allChooceAnswer.Add(420, new Choose_Answer(420, "гулял", 4, null, -1));
            allChooceAnswer.Add(428, new Choose_Answer(428, "1 км.", 4, null, -1));
            allChooceAnswer.Add(438, new Choose_Answer(438, "таксист", 4, null, -1));
            allChooceAnswer.Add(448, new Choose_Answer(448, "пешеходная дорожка", 4, null, -1));
            allChooceAnswer.Add(439, new Choose_Answer(439, "незнакомый", 5, null, -1));
            allChooceAnswer.Add(402, new Choose_Answer(402, "друзья", 5, null, -1));
            allChooceAnswer.Add(338, new Choose_Answer(338, "микроавтобус ", 5, null, -1));
            allChooceAnswer.Add(265, new Choose_Answer(265, "снежный накат", 5, null, -1));
            allChooceAnswer.Add(311, new Choose_Answer(311, "6", 5, null, -1));
            allChooceAnswer.Add(275, new Choose_Answer(275, "6", 5, null, -1));
            allChooceAnswer.Add(237, new Choose_Answer(237, "5", 5, null, -1));
            allChooceAnswer.Add(191, new Choose_Answer(191, "r1.6", 5, getImageFromFile("r1.6.bmp"), -1));
            allChooceAnswer.Add(72, new Choose_Answer(72, "2.3.4", 5, getImageFromFile("2.3.4.bmp"), -1));
            allChooceAnswer.Add(28, new Choose_Answer(28, "серпатин", 5, null, -1));
            allChooceAnswer.Add(15, new Choose_Answer(15, "ограниченная", 5, null, -1));
            allChooceAnswer.Add(6, new Choose_Answer(6, "из холодного асфальтобетона", 5, null, -1));
            allChooceAnswer.Add(85, new Choose_Answer(85, "3.6", 5, getImageFromFile("3.6.bmp"), -1));
            allChooceAnswer.Add(86, new Choose_Answer(86, "3.7", 6, getImageFromFile("3.7.bmp"), -1));
            allChooceAnswer.Add(7, new Choose_Answer(7, "из грунтов", 6, null, -1));
            allChooceAnswer.Add(16, new Choose_Answer(16, "нулевая", 6, null, -1));
            allChooceAnswer.Add(29, new Choose_Answer(29, "насыпь", 6, null, -1));
            allChooceAnswer.Add(73, new Choose_Answer(73, "2.3.5", 6, getImageFromFile("2.3.5.bmp"), -1));
            allChooceAnswer.Add(192, new Choose_Answer(192, "r1.7", 6, getImageFromFile("r1.7.bmp"), -1));
            allChooceAnswer.Add(276, new Choose_Answer(276, "7", 6, null, -1));
            allChooceAnswer.Add(312, new Choose_Answer(312, "7", 6, null, -1));
            allChooceAnswer.Add(266, new Choose_Answer(266, "метель", 6, null, -1));
            allChooceAnswer.Add(339, new Choose_Answer(339, "автобус", 6, null, -1));
            allChooceAnswer.Add(340, new Choose_Answer(340, "троллейбус", 7, null, -1));
            allChooceAnswer.Add(313, new Choose_Answer(313, "8", 7, null, -1));
            allChooceAnswer.Add(277, new Choose_Answer(277, "8", 7, null, -1));
            allChooceAnswer.Add(193, new Choose_Answer(193, "r1.8", 7, getImageFromFile("r1.8.bmp"), -1));
            allChooceAnswer.Add(74, new Choose_Answer(74, "2.3.6", 7, getImageFromFile("2.3.6.bmp"), -1));
            allChooceAnswer.Add(30, new Choose_Answer(30, "перекресток", 7, null, -1));
            allChooceAnswer.Add(8, new Choose_Answer(8, "обработанные в установке вязким битумом", 7, null, -1));
            allChooceAnswer.Add(87, new Choose_Answer(87, "3.8", 7, getImageFromFile("3.8.bmp"), -1));
            allChooceAnswer.Add(88, new Choose_Answer(88, "3.9", 8, getImageFromFile("3.9.bmp"), -1));
            allChooceAnswer.Add(9, new Choose_Answer(9, "грунтовые неукрепленные", 8, null, -1));
            allChooceAnswer.Add(31, new Choose_Answer(31, "надземные пешеходный переход", 8, null, -1));
            allChooceAnswer.Add(75, new Choose_Answer(75, "2.3.7", 8, getImageFromFile("2.3.7.bmp"), -1));
            allChooceAnswer.Add(194, new Choose_Answer(194, "r1.9", 8, getImageFromFile("r1.9.bmp"), -1));
            allChooceAnswer.Add(278, new Choose_Answer(278, "9", 8, null, -1));
            allChooceAnswer.Add(314, new Choose_Answer(314, "9", 8, null, -1));
            allChooceAnswer.Add(341, new Choose_Answer(341, "трамвай", 8, null, -1));
            allChooceAnswer.Add(315, new Choose_Answer(315, "10", 9, null, -1));
            allChooceAnswer.Add(279, new Choose_Answer(279, "10", 9, null, -1));
            allChooceAnswer.Add(195, new Choose_Answer(195, "r1.10", 9, getImageFromFile("r1.10.bmp"), -1));
            allChooceAnswer.Add(76, new Choose_Answer(76, "2.4", 9, getImageFromFile("2.4.bmp"), -1));
            allChooceAnswer.Add(32, new Choose_Answer(32, "подземный пешеходный переход", 9, null, -1));
            allChooceAnswer.Add(89, new Choose_Answer(89, "3.10", 9, getImageFromFile("3.10.bmp"), -1));
            allChooceAnswer.Add(90, new Choose_Answer(90, "3.11", 10, getImageFromFile("3.11.bmp"), -1));
            allChooceAnswer.Add(77, new Choose_Answer(77, "2.5", 10, getImageFromFile("2.5.bmp"), -1));
            allChooceAnswer.Add(196, new Choose_Answer(196, "r1.11", 10, getImageFromFile("r1.11.bmp"), -1));
            allChooceAnswer.Add(280, new Choose_Answer(280, "11", 10, null, -1));
            allChooceAnswer.Add(316, new Choose_Answer(316, "11", 10, null, -1));
            allChooceAnswer.Add(317, new Choose_Answer(317, "12", 11, null, -1));
            allChooceAnswer.Add(281, new Choose_Answer(281, "12", 11, null, -1));
            allChooceAnswer.Add(197, new Choose_Answer(197, "r1.12", 11, getImageFromFile("r1.12.bmp"), -1));
            allChooceAnswer.Add(78, new Choose_Answer(78, "2.6", 11, getImageFromFile("2.6.bmp"), -1));
            allChooceAnswer.Add(91, new Choose_Answer(91, "3.12", 11, getImageFromFile("3.12.bmp"), -1));
            allChooceAnswer.Add(92, new Choose_Answer(92, "3.13", 12, getImageFromFile("3.13.bmp"), -1));
            allChooceAnswer.Add(79, new Choose_Answer(79, "2.7", 12, getImageFromFile("2.7.bmp"), -1));
            allChooceAnswer.Add(198, new Choose_Answer(198, "r1.13", 12, getImageFromFile("r1.13.bmp"), -1));
            allChooceAnswer.Add(199, new Choose_Answer(199, "r1.14.1", 13, getImageFromFile("r1.14.1.bmp"), -1));
            allChooceAnswer.Add(93, new Choose_Answer(93, "3.14", 13, getImageFromFile("3.14.bmp"), -1));
            allChooceAnswer.Add(94, new Choose_Answer(94, "3.15", 14, getImageFromFile("3.15.bmp"), -1));
            allChooceAnswer.Add(200, new Choose_Answer(200, "r1.14.2", 14, getImageFromFile("r1.14.2.bmp"), -1));
            allChooceAnswer.Add(201, new Choose_Answer(201, "r1.15", 15, getImageFromFile("r1.15.bmp"), -1));
            allChooceAnswer.Add(95, new Choose_Answer(95, "3.16", 15, getImageFromFile("3.16.bmp"), -1));
            allChooceAnswer.Add(96, new Choose_Answer(96, "3.17.1", 16, getImageFromFile("3.17.1.bmp"), -1));
            allChooceAnswer.Add(202, new Choose_Answer(202, "r1.16.2", 16, getImageFromFile("r1.16.2.bmp"), -1));
            allChooceAnswer.Add(203, new Choose_Answer(203, "r1.17", 17, getImageFromFile("r1.17.bmp"), -1));
            allChooceAnswer.Add(97, new Choose_Answer(97, "3.17.2", 17, getImageFromFile("3.17.2.bmp"), -1));
            allChooceAnswer.Add(98, new Choose_Answer(98, "3.17.3", 18, getImageFromFile("3.17.3.bmp"), -1));
            allChooceAnswer.Add(204, new Choose_Answer(204, "r1.18", 18, getImageFromFile("r1.18.bmp"), -1));
            allChooceAnswer.Add(205, new Choose_Answer(205, "r1.19", 19, getImageFromFile("r1.19.bmp"), -1));
            allChooceAnswer.Add(99, new Choose_Answer(99, "3.18.1", 19, getImageFromFile("3.18.1.bmp"), -1));
            allChooceAnswer.Add(100, new Choose_Answer(100, "3.18.2", 20, getImageFromFile("3.18.2.bmp"), -1));
            allChooceAnswer.Add(206, new Choose_Answer(206, "r1.20", 20, getImageFromFile("r1.20.bmp"), -1));
            allChooceAnswer.Add(207, new Choose_Answer(207, "r1.21", 21, getImageFromFile("r1.21.bmp"), -1));
            allChooceAnswer.Add(101, new Choose_Answer(101, "3.19", 21, getImageFromFile("3.19.bmp"), -1));
            allChooceAnswer.Add(102, new Choose_Answer(102, "3.20", 22, getImageFromFile("3.20.bmp"), -1));
            allChooceAnswer.Add(208, new Choose_Answer(208, "r1.22", 22, getImageFromFile("r1.22.bmp"), -1));
            allChooceAnswer.Add(209, new Choose_Answer(209, "r1.23", 23, getImageFromFile("r1.23.bmp"), -1));
            allChooceAnswer.Add(103, new Choose_Answer(103, "3.21", 23, getImageFromFile("3.21.bmp"), -1));
            allChooceAnswer.Add(104, new Choose_Answer(104, "3.22", 24, getImageFromFile("3.22.bmp"), -1));
            allChooceAnswer.Add(210, new Choose_Answer(210, "r1.24.1", 24, getImageFromFile("r1.24.1.bmp"), -1));
            allChooceAnswer.Add(211, new Choose_Answer(211, "r1.24.2", 25, getImageFromFile("r1.24.2.bmp"), -1));
            allChooceAnswer.Add(105, new Choose_Answer(105, "3.23", 25, getImageFromFile("3.23.bmp"), -1));
            allChooceAnswer.Add(106, new Choose_Answer(106, "3.24", 26, getImageFromFile("3.24.bmp"), -1));
            allChooceAnswer.Add(212, new Choose_Answer(212, "r1.24.3", 26, getImageFromFile("r1.24.3.bmp"), -1));
            allChooceAnswer.Add(213, new Choose_Answer(213, "r1.25", 27, getImageFromFile("r1.25.bmp"), -1));
            allChooceAnswer.Add(107, new Choose_Answer(107, "3.25", 27, getImageFromFile("3.25.bmp"), -1));
            allChooceAnswer.Add(108, new Choose_Answer(108, "3.26", 28, getImageFromFile("3.26.bmp"), -1));
            allChooceAnswer.Add(214, new Choose_Answer(214, "r2.1.3", 28, getImageFromFile("r2.1.3.bmp"), -1));
            allChooceAnswer.Add(215, new Choose_Answer(215, "r2.2", 29, getImageFromFile("r2.2.bmp"), -1));
            allChooceAnswer.Add(109, new Choose_Answer(109, "3.27", 29, getImageFromFile("3.27.bmp"), -1));
            allChooceAnswer.Add(110, new Choose_Answer(110, "3.28", 30, getImageFromFile("3.28.bmp"), -1));
            allChooceAnswer.Add(216, new Choose_Answer(216, "r2.3", 30, getImageFromFile("r2.3.bmp"), -1));
            allChooceAnswer.Add(217, new Choose_Answer(217, "r2.4", 31, getImageFromFile("r2.4.bmp"), -1));
            allChooceAnswer.Add(111, new Choose_Answer(111, "3.29", 31, getImageFromFile("3.29.bmp"), -1));
            allChooceAnswer.Add(112, new Choose_Answer(112, "3.30", 32, getImageFromFile("3.30.bmp"), -1));
            allChooceAnswer.Add(218, new Choose_Answer(218, "r2.5", 32, getImageFromFile("r2.5.bmp"), -1));
            allChooceAnswer.Add(219, new Choose_Answer(219, "r2.6", 33, getImageFromFile("r2.6.bmp"), -1));
            allChooceAnswer.Add(113, new Choose_Answer(113, "3.31", 33, getImageFromFile("3.31.bmp"), -1));
            allChooceAnswer.Add(114, new Choose_Answer(114, "2.7", 34, getImageFromFile("2.7.bmp"), -1));
            allChooceAnswer.Add(220, new Choose_Answer(220, "r2.7", 34, getImageFromFile("r2.7.bmp"), -1));
            allChooceAnswer.Add(221, new Choose_Answer(221, "r1.1", 35, getImageFromFile("r1.1.bmp"), -1));
            allChooceAnswer.Add(115, new Choose_Answer(115, "2.1", 35, getImageFromFile("2.1.bmp"), -1));
            allChooceAnswer.Add(116, new Choose_Answer(116, "2.2", 36, getImageFromFile("2.2.bmp"), -1));
            allChooceAnswer.Add(117, new Choose_Answer(117, "2.3.1", 37, getImageFromFile("2.3.1.bmp"), -1));
            allChooceAnswer.Add(118, new Choose_Answer(118, "2.3.2", 38, getImageFromFile("2.3.2.bmp"), -1));
            allChooceAnswer.Add(119, new Choose_Answer(119, "2.3.3", 39, getImageFromFile("2.3.3.bmp"), -1));
            allChooceAnswer.Add(120, new Choose_Answer(120, "2.3.4", 40, getImageFromFile("2.3.4.bmp"), -1));
            allChooceAnswer.Add(121, new Choose_Answer(121, "2.3.5", 41, getImageFromFile("2.3.5.bmp"), -1));
            allChooceAnswer.Add(122, new Choose_Answer(122, "2.3.6", 42, getImageFromFile("2.3.6.bmp"), -1));
            allChooceAnswer.Add(123, new Choose_Answer(123, "2.3.7", 43, getImageFromFile("2.3.7.bmp"), -1));
            allChooceAnswer.Add(124, new Choose_Answer(124, "2.4", 44, getImageFromFile("2.4.bmp"), -1));
            allChooceAnswer.Add(125, new Choose_Answer(125, "2.5", 45, getImageFromFile("2.5.bmp"), -1));
            allChooceAnswer.Add(126, new Choose_Answer(126, "2.6", 46, getImageFromFile("2.6.bmp"), -1));
            allChooceAnswer.Add(127, new Choose_Answer(127, "4.8.2", 47, getImageFromFile("4.8.2.bmp"), -1));
            allChooceAnswer.Add(128, new Choose_Answer(128, "4.1.1", 48, getImageFromFile("4.1.1.bmp"), -1));
            allChooceAnswer.Add(129, new Choose_Answer(129, "4.1.2", 49, getImageFromFile("4.1.2.bmp"), -1));
            allChooceAnswer.Add(130, new Choose_Answer(130, "4.1.3", 50, getImageFromFile("4.1.3.bmp"), -1));
            allChooceAnswer.Add(131, new Choose_Answer(131, "4.1.4", 51, getImageFromFile("4.1.4.bmp"), -1));
            allChooceAnswer.Add(132, new Choose_Answer(132, "4.1.5", 52, getImageFromFile("4.1.5.bmp"), -1));
            allChooceAnswer.Add(133, new Choose_Answer(133, "4.1.6", 53, getImageFromFile("4.1.6.bmp"), -1));
            allChooceAnswer.Add(134, new Choose_Answer(134, "4.2.1", 54, getImageFromFile("4.2.1.bmp"), -1));
            allChooceAnswer.Add(135, new Choose_Answer(135, "4.2.2", 55, getImageFromFile("4.2.2.bmp"), -1));
            allChooceAnswer.Add(136, new Choose_Answer(136, "4.2.3", 56, getImageFromFile("4.2.3.bmp"), -1));
            allChooceAnswer.Add(137, new Choose_Answer(137, "4.3", 57, getImageFromFile("4.3.bmp"), -1));
            allChooceAnswer.Add(138, new Choose_Answer(138, "4.4", 58, getImageFromFile("4.4.bmp"), -1));
            allChooceAnswer.Add(139, new Choose_Answer(139, "4.5", 59, getImageFromFile("4.5.bmp"), -1));
            allChooceAnswer.Add(140, new Choose_Answer(140, "4.6", 60, getImageFromFile("4.6.bmp"), -1));
            allChooceAnswer.Add(141, new Choose_Answer(141, "4.7", 61, getImageFromFile("4.7.bmp"), -1));
            allChooceAnswer.Add(142, new Choose_Answer(142, "4.8.1", 62, getImageFromFile("4.8.1.bmp"), -1));
            allChooceAnswer.Add(143, new Choose_Answer(143, "1.34.3", 63, getImageFromFile("1.34.3.bmp"), -1));
            allChooceAnswer.Add(144, new Choose_Answer(144, "1.1", 64, getImageFromFile("1.1.bmp"), -1));
            allChooceAnswer.Add(145, new Choose_Answer(145, "1.2", 65, getImageFromFile("1.2.bmp"), -1));
            allChooceAnswer.Add(146, new Choose_Answer(146, "1.3.1", 66, getImageFromFile("1.3.1.bmp"), -1));
            allChooceAnswer.Add(147, new Choose_Answer(147, "1.3.2", 67, getImageFromFile("1.3.2.bmp"), -1));
            allChooceAnswer.Add(148, new Choose_Answer(148, "1.4.1", 68, getImageFromFile("1.4.1.bmp"), -1));
            allChooceAnswer.Add(149, new Choose_Answer(149, "1.4.2", 69, getImageFromFile("1.4.2.bmp"), -1));
            allChooceAnswer.Add(150, new Choose_Answer(150, "1.4.3", 70, getImageFromFile("1.4.3.bmp"), -1));
            allChooceAnswer.Add(151, new Choose_Answer(151, "1.5", 71, getImageFromFile("1.5.bmp"), -1));
            allChooceAnswer.Add(152, new Choose_Answer(152, "1.6", 72, getImageFromFile("1.6.bmp"), -1));
            allChooceAnswer.Add(153, new Choose_Answer(153, "1.7", 73, getImageFromFile("1.7.bmp"), -1));
            allChooceAnswer.Add(154, new Choose_Answer(154, "1.8", 74, getImageFromFile("1.8.bmp"), -1));
            allChooceAnswer.Add(155, new Choose_Answer(155, "1.9", 75, getImageFromFile("1.9.bmp"), -1));
            allChooceAnswer.Add(156, new Choose_Answer(156, "1.10", 76, getImageFromFile("1.10.bmp"), -1));
            allChooceAnswer.Add(157, new Choose_Answer(157, "1.11.1", 77, getImageFromFile("1.11.1.bmp"), -1));
            allChooceAnswer.Add(158, new Choose_Answer(158, "1.11.2", 78, getImageFromFile("1.11.2.bmp"), -1));
            allChooceAnswer.Add(159, new Choose_Answer(159, "1.12.1", 79, getImageFromFile("1.12.1.bmp"), -1));
            allChooceAnswer.Add(160, new Choose_Answer(160, "1.12.2", 80, getImageFromFile("1.12.2.bmp"), -1));
            allChooceAnswer.Add(161, new Choose_Answer(161, "1.13", 81, getImageFromFile("1.13.bmp"), -1));
            allChooceAnswer.Add(162, new Choose_Answer(162, "1.14", 82, getImageFromFile("1.14.bmp"), -1));
            allChooceAnswer.Add(163, new Choose_Answer(163, "1.15", 83, getImageFromFile("1.15.bmp"), -1));
            allChooceAnswer.Add(164, new Choose_Answer(164, "1.16", 84, getImageFromFile("1.16.bmp"), -1));
            allChooceAnswer.Add(165, new Choose_Answer(165, "1.17", 85, getImageFromFile("1.17.bmp"), -1));
            allChooceAnswer.Add(166, new Choose_Answer(166, "1.18", 86, getImageFromFile("1.18.bmp"), -1));
            allChooceAnswer.Add(167, new Choose_Answer(167, "1.19", 87, getImageFromFile("1.19.bmp"), -1));
            allChooceAnswer.Add(168, new Choose_Answer(168, "1.20.1", 88, getImageFromFile("1.20.1.bmp"), -1));
            allChooceAnswer.Add(169, new Choose_Answer(169, "1.20.2", 89, getImageFromFile("1.20.2.bmp"), -1));
            allChooceAnswer.Add(170, new Choose_Answer(170, "1.20.3", 90, getImageFromFile("1.20.3.bmp"), -1));
            allChooceAnswer.Add(171, new Choose_Answer(171, "1.21", 91, getImageFromFile("1.21.bmp"), -1));
            allChooceAnswer.Add(172, new Choose_Answer(172, "1.22", 92, getImageFromFile("1.22.bmp"), -1));
            allChooceAnswer.Add(173, new Choose_Answer(173, "1.23", 93, getImageFromFile("1.23.bmp"), -1));
            allChooceAnswer.Add(174, new Choose_Answer(174, "1.24", 94, getImageFromFile("1.24.bmp"), -1));
            allChooceAnswer.Add(175, new Choose_Answer(175, "1.25", 95, getImageFromFile("1.25.bmp"), -1));
            allChooceAnswer.Add(176, new Choose_Answer(176, "1.26", 96, getImageFromFile("1.26.bmp"), -1));
            allChooceAnswer.Add(177, new Choose_Answer(177, "1.27", 97, getImageFromFile("1.27.bmp"), -1));
            allChooceAnswer.Add(178, new Choose_Answer(178, "1.28", 98, getImageFromFile("1.28.bmp"), -1));
            allChooceAnswer.Add(179, new Choose_Answer(179, "1.29", 99, getImageFromFile("1.29.bmp"), -1));
            allChooceAnswer.Add(180, new Choose_Answer(180, "1.30", 100, getImageFromFile("1.30.bmp"), -1));
            allChooceAnswer.Add(181, new Choose_Answer(181, "1.31", 101, getImageFromFile("1.31.bmp"), -1));
            allChooceAnswer.Add(182, new Choose_Answer(182, "1.32", 102, getImageFromFile("1.32.bmp"), -1));
            allChooceAnswer.Add(183, new Choose_Answer(183, "1.33", 103, getImageFromFile("1.33.bmp"), -1));
            allChooceAnswer.Add(184, new Choose_Answer(184, "1.34.1", 104, getImageFromFile("1.34.1.bmp"), -1));
            allChooceAnswer.Add(185, new Choose_Answer(185, "1.34.2", 105, getImageFromFile("1.34.2.bmp"), -1));
            allFeatureImages.Add(135, new FEATURE_IMAGE(135, "Наименование", 0, new int[] { }, null, null));
            allFeatureImages.Add(142, new FEATURE_IMAGE(142, "В каком часу произошло дтп?", 1, new int[] { }, null, null));
            allFeatureImages.Add(136, new FEATURE_IMAGE(136, "Адрес", 0, new int[] { }, null, null));
            allFeatureImages.Add(137, new FEATURE_IMAGE(137, "Директор", 0, new int[] { }, null, null));
            allFeatureImages.Add(138, new FEATURE_IMAGE(138, "Ответственный по предупреждению детского травматизма", 0, new int[] { }, null, null));
            allFeatureImages.Add(139, new FEATURE_IMAGE(139, "Заместитель по воспитательной работе", 0, new int[] { }, null, null));
            allFeatureImages.Add(140, new FEATURE_IMAGE(140, "Сведения по факту проверки", 0, new int[] { }, null, null));
            allFeatureImages.Add(127, new FEATURE_IMAGE(127, "Категория водительских прав", 0, new int[] { 440, 441, 442, 443 }, null, null));
            allFeatureImages.Add(128, new FEATURE_IMAGE(128, "Дата выдачи водительских прав", 0, new int[] { }, @"return currEssence.getFeatureByImage(127)[0].answer !=null;", null));
            allFeatureImages.Add(129, new FEATURE_IMAGE(129, "Место выдачи ", 0, new int[] { }, @"return currEssence.getFeatureByImage(127)[0].answer !=null;", null));
            allFeatureImages.Add(130, new FEATURE_IMAGE(130, "Общий стаж ", 0, new int[] { }, null, null));
            allFeatureImages.Add(131, new FEATURE_IMAGE(131, "Стаж управления данной категории ", 0, new int[] { }, null, null));
            allFeatureImages.Add(132, new FEATURE_IMAGE(132, "Дата последнего медицинского освидетельсвоания ", 5, new int[] { }, null, null));
            allFeatureImages.Add(133, new FEATURE_IMAGE(133, "Проходил предрейсовый осмотр?", 3, new int[] { }, @"if  (currEssence.getFeatureByImage(104)[0].answer!=null &&
 currEssence.getFeatureByImage(104)[0].answer.eAnswer.hasEssence(18))
{
     if (  currEssence.getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(70)[0].answer  !=null &&
              ( currEssence.getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(70)[0].answer.intAnswer==0 ||  currEssence.getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(70)[0].answer.intAnswer==1 )) return true;
}


return false;", null));
            allFeatureImages.Add(125, new FEATURE_IMAGE(125, "Наличие удерживающий устройств", 3, new int[] { }, null, null));
            allFeatureImages.Add(126, new FEATURE_IMAGE(126, "Взаимоотношения с водителем", 0, new int[] { 434, 435, 436, 437, 438, 439 }, null, null));
            allFeatureImages.Add(124, new FEATURE_IMAGE(124, "Место в машине", 0, new int[] { 430, 431, 432, 433 }, null, null));
            allFeatureImages.Add(120, new FEATURE_IMAGE(120, "Наличие документов на право управления ТС", 3, new int[] { }, null, null));
            allFeatureImages.Add(121, new FEATURE_IMAGE(121, "Каким образом несовершеннолетний оказался за рулем ТС", 0, new int[] { }, null, null));
            allFeatureImages.Add(122, new FEATURE_IMAGE(122, "Родители в курсе?", 3, new int[] { }, null, null));
            allFeatureImages.Add(123, new FEATURE_IMAGE(123, "Привлекались ли родители к административной ответственности", 3, new int[] { 457 }, null, null));
            allFeatureImages.Add(117, new FEATURE_IMAGE(117, "Направление движения", 0, new int[] { 416, 417, 418, 419, 420 }, null, null));
            allFeatureImages.Add(118, new FEATURE_IMAGE(118, "Маршрут движения  ", 0, new int[] { 421, 422, 423 }, null, null));
            allFeatureImages.Add(119, new FEATURE_IMAGE(119, "Удаленность от образовательного учреждения или дома", 0, new int[] { 424, 425, 426, 427, 428 }, null, null));
            allFeatureImages.Add(109, new FEATURE_IMAGE(109, "Место совершения наяезда", 0, new int[] { 386, 387, 388, 389, 390 }, null, null));
            allFeatureImages.Add(106, new FEATURE_IMAGE(106, "Цветовая гамма одежды", 0, new int[] { 391, 392, 393 }, null, null));
            allFeatureImages.Add(99, new FEATURE_IMAGE(99, "Характер травм", 0, new int[] { }, null, null));
            allFeatureImages.Add(100, new FEATURE_IMAGE(100, "Тяжесть травм", 0, new int[] { }, null, null));
            allFeatureImages.Add(107, new FEATURE_IMAGE(107, "Светоотражающие элементы", 0, new int[] { 394, 395, 396 }, null, null));
            allFeatureImages.Add(101, new FEATURE_IMAGE(101, "Сведения о госпитализации", 0, new int[] { 360 }, null, null));
            allFeatureImages.Add(97, new FEATURE_IMAGE(97, "Посещаемая образовательная организация", 6, new int[] { 359 }, null, null));
            allFeatureImages.Add(98, new FEATURE_IMAGE(98, "Класс", 0, new int[] { }, @"return currEssence.getFeatureByImage(97)[0].answer !=null;", null));
            allFeatureImages.Add(110, new FEATURE_IMAGE(110, "Сопровождающие на момент ДТП", 0, new int[] { 397, 398, 399, 400, 401, 402 }, null, null));
            allFeatureImages.Add(92, new FEATURE_IMAGE(92, "ФИО", 0, new int[] { }, null, @" if ( currFeature.answer!=null)
   currEssence.sName=  currFeature.answer.sAnswer;"));
            allFeatureImages.Add(93, new FEATURE_IMAGE(93, "Дата Рождения", 5, new int[] { }, null, null));
            allFeatureImages.Add(94, new FEATURE_IMAGE(94, "Адрес регистрации", 0, new int[] { }, null, null));
            allFeatureImages.Add(95, new FEATURE_IMAGE(95, "Адрес проживания", 0, new int[] { }, @"return currEssence.getFeatureByImage(94)[0].answer !=null;", null));
            allFeatureImages.Add(96, new FEATURE_IMAGE(96, "Категория участника ДТП", 2, new int[] { 355, 356, 357, 358 }, null, null));
            allFeatureImages.Add(104, new FEATURE_IMAGE(104, "ТС участника", 6, new int[] { 459 }, @"if (currEssence.getFeatureByImage(96)[0].answer !=null &&
 ( currEssence.getFeatureByImage(96)[0].answer.intAnswer==1 ||
  currEssence.getFeatureByImage(96)[0].answer.intAnswer==3 )  ) return true;
return false;", @" if ( !currEssence.hasEssence(22) || currFeature.answer==null ) return;

 if (  currFeature.answer.eAnswer.getFeatureByImage(68)[0].answer!=null &&
   currFeature.answer.eAnswer.getFeatureByImage(68)[0].answer.eAnswer== currEssence ) return;

 currFeature.answer.eAnswer.getFeatureByImage(68)[0].setAnswer( currEssence);"));
            allFeatureImages.Add(103, new FEATURE_IMAGE(103, "Пострадавший", 3, new int[] { }, null, null));
            allFeatureImages.Add(73, new FEATURE_IMAGE(73, "Марка", 0, new int[] { }, null, null));
            allFeatureImages.Add(74, new FEATURE_IMAGE(74, "Модель", 0, new int[] { }, @"return currEssence.getFeatureByImage(73)[0].answer!=null;", null));
            allFeatureImages.Add(75, new FEATURE_IMAGE(75, "Государственный регистрационный знак", 0, new int[] { }, null, @" if ( currFeature.answer!=null )
     currEssence.sName= currFeature.answer.sAnswer;
"));
            allFeatureImages.Add(70, new FEATURE_IMAGE(70, "Владелец ТС", 2, new int[] { 454, 455, 456 }, null, null));
            allFeatureImages.Add(71, new FEATURE_IMAGE(71, "Наименование компании", 0, new int[] { }, @"if (currEssence.getFeatureByImage(70)[0].answer!=null && (
currEssence.getFeatureByImage(70)[0].answer.intAnswer==0 || 
currEssence.getFeatureByImage(70)[0].answer.intAnswer==1)) return true;
return false;  ", null));
            allFeatureImages.Add(72, new FEATURE_IMAGE(72, "Собственник", 6, new int[] { 354 }, @"if (currEssence.getFeatureByImage(70)[0].answer!=null &&
 currEssence.getFeatureByImage(70)[0].answer.intAnswer==2) return true;
return false;", null));
            allFeatureImages.Add(76, new FEATURE_IMAGE(76, "Полис ОСАГО", 0, new int[] { }, null, null));
            allFeatureImages.Add(77, new FEATURE_IMAGE(77, "VIN номер", 0, new int[] { }, null, null));
            allFeatureImages.Add(78, new FEATURE_IMAGE(78, "Номер кузова", 0, new int[] { }, null, null));
            allFeatureImages.Add(79, new FEATURE_IMAGE(79, "Год выпуска", 0, new int[] { }, null, null));
            allFeatureImages.Add(80, new FEATURE_IMAGE(80, "Общий пробег", 0, new int[] { }, null, null));
            allFeatureImages.Add(81, new FEATURE_IMAGE(81, "Дата проведения тех. обслуживания", 5, new int[] { }, null, null));
            allFeatureImages.Add(82, new FEATURE_IMAGE(82, "Пробег после тех. обслуживания", 0, new int[] { }, null, null));
            allFeatureImages.Add(83, new FEATURE_IMAGE(83, "Цвет", 0, new int[] { }, null, null));
            allFeatureImages.Add(84, new FEATURE_IMAGE(84, "Тонировка передней полусферы", 3, new int[] { }, null, null));
            allFeatureImages.Add(85, new FEATURE_IMAGE(85, "Видеорегистратор", 3, new int[] { }, null, null));
            allFeatureImages.Add(86, new FEATURE_IMAGE(86, "Пассажировместимость", 1, new int[] { }, null, null));
            allFeatureImages.Add(87, new FEATURE_IMAGE(87, "Количество пассажиров на момент ДТП", 1, new int[] { }, null, null));
            allFeatureImages.Add(88, new FEATURE_IMAGE(88, "Грузоподьемность (тонн)", 1, new int[] { }, null, null));
            allFeatureImages.Add(89, new FEATURE_IMAGE(89, "Груз на момент дтп (тонн)", 1, new int[] { }, null, null));
            allFeatureImages.Add(90, new FEATURE_IMAGE(90, "Адрес стоянки", 0, new int[] { }, null, null));
            allFeatureImages.Add(91, new FEATURE_IMAGE(91, "Дополнительно", 0, new int[] { }, null, null));
            allFeatureImages.Add(63, new FEATURE_IMAGE(63, "Время прибытия ДПС на место ДТП", 5, new int[] { }, null, null));
            allFeatureImages.Add(64, new FEATURE_IMAGE(64, "Где был патруль во время ДТП", 0, new int[] { }, null, null));
            allFeatureImages.Add(113, new FEATURE_IMAGE(113, "Соответсвие места нахождения сотрудника ДПС указаниям дежурной части", 3, new int[] { }, @"return currEssence.getFeatureByImage(64)[0].answer != null;", null));
            allFeatureImages.Add(65, new FEATURE_IMAGE(65, "Время прибытия скорой помощи", 5, new int[] { }, null, null));
            allFeatureImages.Add(66, new FEATURE_IMAGE(66, "Время прибытия МЧС", 5, new int[] { }, null, null));
            allFeatureImages.Add(67, new FEATURE_IMAGE(67, "Дополнительно", 0, new int[] { }, null, null));
            allFeatureImages.Add(60, new FEATURE_IMAGE(60, "Тип ТС", 2, new int[] { 320, 321 }, null, null));
            allFeatureImages.Add(61, new FEATURE_IMAGE(61, "Разновидность ТС", 0, new int[] { 333, 334, 335, 336, 337, 338, 339, 340, 341 }, @"if (currEssence.getFeatureByImage(60)[0].answer!=null  &&
 currEssence.getFeatureByImage(60)[0].answer.intAnswer == 0) return true;
return false;", null));
            allFeatureImages.Add(62, new FEATURE_IMAGE(62, "Разновидность немеханических ТС ", 0, new int[] { 374, 375 }, @"if (currEssence.getFeatureByImage(60)[0].answer!=null  &&
 currEssence.getFeatureByImage(60)[0].answer.intAnswer == 1) return true;
return false;", null));
            allFeatureImages.Add(68, new FEATURE_IMAGE(68, "Водитель", 6, new int[] { 458 }, null, @"if (currFeature.answer==null)return;

if ( currFeature.answer.eAnswer.getFeatureByImage(104)[0].answer != null &&
 currFeature.answer.eAnswer.getFeatureByImage(104)[0].answer.eAnswer== currEssence ) return;      

 currFeature.answer.eAnswer.getFeatureByImage(104)[0].setAnswer( currEssence);

"));
            allFeatureImages.Add(108, new FEATURE_IMAGE(108, "Обрудование велосипеда", 4, new int[] { 381, 382, 383, 384, 385 }, @"if (currEssence.getFeatureByImage(62)[0].answer!= null &&
 currEssence.getFeatureByImage(62)[0].answer.intAnswer==0 ) return true;
return false;", null));
            allFeatureImages.Add(56, new FEATURE_IMAGE(56, "Дата", 5, new int[] { }, null, null));
            allFeatureImages.Add(105, new FEATURE_IMAGE(105, "Место ДТП", 0, new int[] { }, null, null));
            allFeatureImages.Add(58, new FEATURE_IMAGE(58, "Предварительно установленная причина", 0, new int[] { }, null, null));
            allFeatureImages.Add(6, new FEATURE_IMAGE(6, "Тип покрытия", 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null, null));
            allFeatureImages.Add(7, new FEATURE_IMAGE(7, "Видимость", 0, new int[] { 10, 11, 12, 13, 14, 15, 16 }, null, null));
            allFeatureImages.Add(8, new FEATURE_IMAGE(8, "Радиус кривизны", 2, new int[] { 17, 18, 19, 20 }, null, null));
            allFeatureImages.Add(9, new FEATURE_IMAGE(9, "Радиус (в м.)", 1, new int[] { }, @"if ( DataProject.getEssencesByImage(5)[0].getFeatureByImage(8)[0].answer != null && DataProject.getEssencesByImage(5)[0].getFeatureByImage(8)[0].answer.intAnswer ==1)
return true;
else return false;", null));
            allFeatureImages.Add(10, new FEATURE_IMAGE(10, "Состояние проезжей части", 0, new int[] { 21, 22 }, null, null));
            allFeatureImages.Add(54, new FEATURE_IMAGE(54, "Сколько ТС в ДТП", 1, new int[] { }, @" int count = DataProject.getEssencesByImage(6).Count;
 if ( currFeature.answer== null || currFeature.answer.intAnswer!= count )
{
     DataStructures.Answer answer = new Answer( count," + "\"" + @"" + "\"" + @"+ count);
     currFeature.setAnswer( answer, " + "\"" + @"system" + "\"" + @" );
}
return true; ", @"if ( currFeature.answer==null) return; 
int count = DataProject.getEssencesByImage(6).Count;
int countAnswer = currFeature.answer.intAnswer;
if ( count < countAnswer )
{
   for (int i=count ; i< countAnswer; ++i )
   {
       Essence es = new Essence ( 6, " + "\"" + @"ТС " + "\"" + @"+ (i+1) );
       DataProject.rootData.Add(es);
   }
}/* else 
{
   for (int i=countAnswer ; i> count; --i )
   {
       DataProject.rootData.RemoveAt( DataProject.rootData.Count -1 );
   }
}*/"));
            allFeatureImages.Add(55, new FEATURE_IMAGE(55, "Сколько Участников ДТП", 1, new int[] { }, @" int count = DataProject.getEssencesByImage(7).Count;

if ( currFeature.answer==null || currFeature.answer.intAnswer !=count )
{
     DataStructures.Answer answer = new Answer( count," + "\"" + @"" + "\"" + @"+ count);
     currFeature.setAnswer( answer, " + "\"" + @"system" + "\"" + @" );
}
return true; ", @"if ( currFeature.answer==null) return; 
int count = DataProject.getEssencesByImage( 7 ).Count;
int countAnswer = currFeature.answer.intAnswer;
if ( count < countAnswer )
{
   for (int i=count ; i< countAnswer; ++i )
   {
       Essence es = new Essence ( 7, " + "\"" + @"Участник " + "\"" + @"+ (i+1) );
       DataProject.rootData.Add(es);
   }
} /*else 
{
   for (int i=countAnswer ; i> count; --i )
   {
       DataProject.rootData.RemoveAt( DataProject.rootData.Count -1 );
   }
}*/"));
            allFeatureImages.Add(11, new FEATURE_IMAGE(11, "Дорожные сооружения", 4, new int[] { 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 }, null, null));
            allFeatureImages.Add(12, new FEATURE_IMAGE(12, "Дорожные знаки", 4, new int[] { 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185 }, null, null));
            allFeatureImages.Add(14, new FEATURE_IMAGE(14, "Дорожная разметка", 4, new int[] { 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221 }, null, null));
            allFeatureImages.Add(112, new FEATURE_IMAGE(112, "Наличие пешеходных дорожек, тротуаров и т.д.", 0, new int[] { 444, 445, 446, 447, 448 }, @"return DataProject.getEssencesByImage(14).Count>0;", null));
            allFeatureImages.Add(15, new FEATURE_IMAGE(15, "Установленное ограничение скорости на данном УДС", 0, new int[] { 222, 223, 224, 225 }, null, null));
            allFeatureImages.Add(16, new FEATURE_IMAGE(16, "Эксплуатационное состояние ПС", 0, new int[] { 232, 233, 234, 235, 236, 237 }, null, null));
            allFeatureImages.Add(17, new FEATURE_IMAGE(17, "Состояние обочины", 0, new int[] { 238, 239, 240 }, null, null));
            allFeatureImages.Add(18, new FEATURE_IMAGE(18, "Ширина обочины", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(17)[0].answer!=null && DataProject.getEssencesByImage(5)[0].getFeatureByImage(17)[0].answer.intAnswer!=0) return true;
return false;", null));
            allFeatureImages.Add(19, new FEATURE_IMAGE(19, "Тип ограждения", 0, new int[] { 241, 242, 243 }, null, null));
            allFeatureImages.Add(21, new FEATURE_IMAGE(21, "Тип освещения", 0, new int[] { 449, 450, 451, 452 }, null, null));
            allFeatureImages.Add(22, new FEATURE_IMAGE(22, "Регулировение движения", 0, new int[] { 252, 253 }, null, null));
            allFeatureImages.Add(23, new FEATURE_IMAGE(23, "Время суток", 0, new int[] { 254, 255, 256 }, null, null));
            allFeatureImages.Add(24, new FEATURE_IMAGE(24, "Дорожные условия", 0, new int[] { 257, 258, 259 }, null, null));
            allFeatureImages.Add(25, new FEATURE_IMAGE(25, "Погодные условия", 0, new int[] { 260, 261, 262, 263, 264, 265, 266 }, null, null));
            allFeatureImages.Add(26, new FEATURE_IMAGE(26, "Принадлежность ПС", 0, new int[] { 267, 268, 269 }, null, null));
            allFeatureImages.Add(27, new FEATURE_IMAGE(27, "Колличество полос в одну сторону", 2, new int[] { 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281 }, null, null));
            allFeatureImages.Add(29, new FEATURE_IMAGE(29, "Ширина 1 полосы", 0, new int[] { }, null, null));
            allFeatureImages.Add(30, new FEATURE_IMAGE(30, "Ширина 2 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>0) return true;
return false;", null));
            allFeatureImages.Add(31, new FEATURE_IMAGE(31, "Ширина 3 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>1) return true;
return false;", null));
            allFeatureImages.Add(32, new FEATURE_IMAGE(32, "Ширина 3 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>2) return true;
return false;", null));
            allFeatureImages.Add(33, new FEATURE_IMAGE(33, "Ширина 5 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>3) return true;
return false;", null));
            allFeatureImages.Add(34, new FEATURE_IMAGE(34, "Ширина 6 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>4) return true;
return false;", null));
            allFeatureImages.Add(35, new FEATURE_IMAGE(35, "Ширина 7 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>5) return true;
return false;
", null));
            allFeatureImages.Add(36, new FEATURE_IMAGE(36, "Ширина 8 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>6) return true;
return false;", null));
            allFeatureImages.Add(37, new FEATURE_IMAGE(37, "Ширина 9 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>7) return true;
return false;", null));
            allFeatureImages.Add(38, new FEATURE_IMAGE(38, "Ширина 10 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>8) return true;
return false;", null));
            allFeatureImages.Add(39, new FEATURE_IMAGE(39, "Ширина 11 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>9) return true;
return false;", null));
            allFeatureImages.Add(40, new FEATURE_IMAGE(40, "Ширина 12 полосы", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>10) return true;
return false;", null));
            allFeatureImages.Add(28, new FEATURE_IMAGE(28, "Количество полос встречного направления", 2, new int[] { 306, 307, 308, 309, 310, 311, 312, 313, 314, 315, 316, 317 }, null, null));
            allFeatureImages.Add(41, new FEATURE_IMAGE(41, "Ширина 1 полосы (встр. напр.) ", 0, new int[] { }, null, null));
            allFeatureImages.Add(42, new FEATURE_IMAGE(42, "Ширина 2 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>0) return true;
return false;", null));
            allFeatureImages.Add(43, new FEATURE_IMAGE(43, "Ширина 3 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>1) return true;
return false;", null));
            allFeatureImages.Add(44, new FEATURE_IMAGE(44, "Ширина 4 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>2) return true;
return false;", null));
            allFeatureImages.Add(45, new FEATURE_IMAGE(45, "Ширина 5 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>3) return true;
return false;", null));
            allFeatureImages.Add(46, new FEATURE_IMAGE(46, "Ширина 6 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>4) return true;
return false;", null));
            allFeatureImages.Add(47, new FEATURE_IMAGE(47, "Ширина 7 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>5) return true;
return false;", null));
            allFeatureImages.Add(48, new FEATURE_IMAGE(48, "Ширина 8 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>6) return true;
return false;", null));
            allFeatureImages.Add(49, new FEATURE_IMAGE(49, "Ширина 9 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>7) return true;
return false;", null));
            allFeatureImages.Add(50, new FEATURE_IMAGE(50, "Ширина 10 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>8) return true;
return false;", null));
            allFeatureImages.Add(51, new FEATURE_IMAGE(51, "Ширина 11 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>9) return true;
return false;", null));
            allFeatureImages.Add(52, new FEATURE_IMAGE(52, "Ширина 12 полосы (встр. напр.)", 0, new int[] { }, @"if (DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer!=null &&
DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.intAnswer>10) return true;
return false;", null));
            allFeatureImages.Add(53, new FEATURE_IMAGE(53, "Дополнительно", 0, new int[] { }, null, null));
            allFeatureImages.Add(1, new FEATURE_IMAGE(1, "Имя", 0, new int[] { }, null, null));
            allFeatureImages.Add(2, new FEATURE_IMAGE(2, "Возраст", 0, new int[] { }, null, null));
            allFeatureImages.Add(3, new FEATURE_IMAGE(3, "стаж", 0, new int[] { }, null, null));
            allFeatureImages.Add(4, new FEATURE_IMAGE(4, "степень повреждений", 0, new int[] { }, null, null));
            allFeatureImages.Add(5, new FEATURE_IMAGE(5, "место в машине", 0, new int[] { }, null, null));
        }


        public static Essence createByImage(ESSENSES_IMEG image)
        {

            Essence es = new Essence(image.dbId, image.name, (ESSENSE_FLAGS)image.flag, image.script, null, null);

            //List<Essence> abstEssences = null;
            if (image.abstEssences != null)
            {
                //es.abstrEssen = new List<Essence>();
                foreach (int abstrImID in image.abstEssences)
                {
                    Essence child=createByImage(getEssenceById(abstrImID));
                    es.abstrEssences.Add(child);
                    child.parentEssence = es;
                }
            }


           
            List<Feature> features = new List<Feature>();


            switch (image.dbId)
            {
                case 8:
                    obj8(es, features);
                    break;
                case 4:
                    obj4(es, features);
                    break;
                case 5:
                    obj5(es, features);
                    break;
                case 6:
                    obj6(es, features);
                    break;
                case 18:
                    obj18(es, features);
                    break;
                case 7:
                    obj7(es, features);
                    break;
                case 11:
                    obj11(es, features);
                    break;
                case 22:
                    obj22(es, features);
                    break;
                case 12:
                    obj12(es, features);
                    break;
                case 13:
                    obj13(es, features);
                    break;
                case 14:
                    obj14(es, features);
                    break;
                case 15:
                    obj15(es, features);
                    break;
                case 19:
                    obj19(es, features);
                    break;
                case 20:
                    obj20(es, features);
                    break;
                case 21:
                    obj21(es, features);
                    break;
                case 16:
                    obj16(es, features);
                    break;
                case 17:
                    obj17(es, features);
                    break;
            }



            es.features = features;
            return es;

        }

        public static List<ESSENSES_IMEG> getEssenceImageByFlag(ESSENSE_FLAGS flag)
        {
            List<ESSENSES_IMEG> result = new List<ESSENSES_IMEG>();
            foreach (ESSENSES_IMEG esIm in allImageEssences)
            {
                if ((esIm.flag & (int)flag) == (int)flag) result.Add(esIm);
            }
            return result;
        }

        public static ESSENSES_IMEG getEssenceImageByID(int id)
        {

            foreach (ESSENSES_IMEG esIm in allImageEssences)
            {
                if (esIm.dbId == id) return esIm;
            }
            return null;
        }



        private static ESSENSES_IMEG getEssenceById(int id)
        {
            foreach (ESSENSES_IMEG im in allImageEssences)
                if (im.dbId == id) return im;
            return null;
        }

        private static Image getImageFromFile(String idNameIfImage)
        {
            String fileName = MyFiles.dir + "\\images\\" + idNameIfImage;
            return Image.FromFile(fileName);
        }

        private static void obj8(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[54].getFeature(es));
            features.Add(allFeatureImages[55].getFeature(es));
        }
        private static void obj4(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[56].getFeature(es));
            features.Add(allFeatureImages[105].getFeature(es));
            features.Add(allFeatureImages[58].getFeature(es));
        }
        private static void obj5(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[6].getFeature(es));
            features.Add(allFeatureImages[7].getFeature(es));
            features.Add(allFeatureImages[8].getFeature(es));
            features.Add(allFeatureImages[9].getFeature(es));
            features.Add(allFeatureImages[10].getFeature(es));
            features.Add(allFeatureImages[11].getFeature(es));
            features.Add(allFeatureImages[12].getFeature(es));
            features.Add(allFeatureImages[14].getFeature(es));
            features.Add(allFeatureImages[112].getFeature(es));
            features.Add(allFeatureImages[15].getFeature(es));
            features.Add(allFeatureImages[16].getFeature(es));
            features.Add(allFeatureImages[17].getFeature(es));
            features.Add(allFeatureImages[18].getFeature(es));
            features.Add(allFeatureImages[19].getFeature(es));
            features.Add(allFeatureImages[21].getFeature(es));
            features.Add(allFeatureImages[22].getFeature(es));
            features.Add(allFeatureImages[23].getFeature(es));
            features.Add(allFeatureImages[24].getFeature(es));
            features.Add(allFeatureImages[25].getFeature(es));
            features.Add(allFeatureImages[26].getFeature(es));
            features.Add(allFeatureImages[27].getFeature(es));
            features.Add(allFeatureImages[29].getFeature(es));
            features.Add(allFeatureImages[30].getFeature(es));
            features.Add(allFeatureImages[31].getFeature(es));
            features.Add(allFeatureImages[32].getFeature(es));
            features.Add(allFeatureImages[33].getFeature(es));
            features.Add(allFeatureImages[34].getFeature(es));
            features.Add(allFeatureImages[35].getFeature(es));
            features.Add(allFeatureImages[36].getFeature(es));
            features.Add(allFeatureImages[37].getFeature(es));
            features.Add(allFeatureImages[38].getFeature(es));
            features.Add(allFeatureImages[39].getFeature(es));
            features.Add(allFeatureImages[40].getFeature(es));
            features.Add(allFeatureImages[28].getFeature(es));
            features.Add(allFeatureImages[41].getFeature(es));
            features.Add(allFeatureImages[42].getFeature(es));
            features.Add(allFeatureImages[43].getFeature(es));
            features.Add(allFeatureImages[44].getFeature(es));
            features.Add(allFeatureImages[45].getFeature(es));
            features.Add(allFeatureImages[46].getFeature(es));
            features.Add(allFeatureImages[47].getFeature(es));
            features.Add(allFeatureImages[48].getFeature(es));
            features.Add(allFeatureImages[49].getFeature(es));
            features.Add(allFeatureImages[50].getFeature(es));
            features.Add(allFeatureImages[51].getFeature(es));
            features.Add(allFeatureImages[52].getFeature(es));
            features.Add(allFeatureImages[53].getFeature(es));
        }
        private static void obj6(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[60].getFeature(es));
            features.Add(allFeatureImages[61].getFeature(es));
            features.Add(allFeatureImages[62].getFeature(es));
            features.Add(allFeatureImages[68].getFeature(es));
            features.Add(allFeatureImages[108].getFeature(es));
        }
        private static void obj18(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[73].getFeature(es));
            features.Add(allFeatureImages[74].getFeature(es));
            features.Add(allFeatureImages[75].getFeature(es));
            features.Add(allFeatureImages[70].getFeature(es));
            features.Add(allFeatureImages[71].getFeature(es));
            features.Add(allFeatureImages[72].getFeature(es));
            features.Add(allFeatureImages[76].getFeature(es));
            features.Add(allFeatureImages[77].getFeature(es));
            features.Add(allFeatureImages[78].getFeature(es));
            features.Add(allFeatureImages[79].getFeature(es));
            features.Add(allFeatureImages[80].getFeature(es));
            features.Add(allFeatureImages[81].getFeature(es));
            features.Add(allFeatureImages[82].getFeature(es));
            features.Add(allFeatureImages[83].getFeature(es));
            features.Add(allFeatureImages[84].getFeature(es));
            features.Add(allFeatureImages[85].getFeature(es));
            features.Add(allFeatureImages[86].getFeature(es));
            features.Add(allFeatureImages[87].getFeature(es));
            features.Add(allFeatureImages[88].getFeature(es));
            features.Add(allFeatureImages[89].getFeature(es));
            features.Add(allFeatureImages[90].getFeature(es));
            features.Add(allFeatureImages[91].getFeature(es));
        }
        private static void obj7(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[92].getFeature(es));
            features.Add(allFeatureImages[93].getFeature(es));
            features.Add(allFeatureImages[94].getFeature(es));
            features.Add(allFeatureImages[95].getFeature(es));
            features.Add(allFeatureImages[96].getFeature(es));
            features.Add(allFeatureImages[104].getFeature(es));
            features.Add(allFeatureImages[103].getFeature(es));
        }
        private static void obj11(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[99].getFeature(es));
            features.Add(allFeatureImages[100].getFeature(es));
            features.Add(allFeatureImages[101].getFeature(es));
        }
        private static void obj22(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[142].getFeature(es));
        }
        private static void obj12(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[127].getFeature(es));
            features.Add(allFeatureImages[128].getFeature(es));
            features.Add(allFeatureImages[129].getFeature(es));
            features.Add(allFeatureImages[130].getFeature(es));
            features.Add(allFeatureImages[131].getFeature(es));
            features.Add(allFeatureImages[132].getFeature(es));
            features.Add(allFeatureImages[133].getFeature(es));
        }
        private static void obj13(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[124].getFeature(es));
        }
        private static void obj14(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[109].getFeature(es));
            features.Add(allFeatureImages[106].getFeature(es));
            features.Add(allFeatureImages[107].getFeature(es));
        }
        private static void obj15(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[97].getFeature(es));
            features.Add(allFeatureImages[98].getFeature(es));
            features.Add(allFeatureImages[110].getFeature(es));
        }
        private static void obj19(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[120].getFeature(es));
            features.Add(allFeatureImages[121].getFeature(es));
            features.Add(allFeatureImages[122].getFeature(es));
            features.Add(allFeatureImages[123].getFeature(es));
        }
        private static void obj20(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[117].getFeature(es));
            features.Add(allFeatureImages[118].getFeature(es));
            features.Add(allFeatureImages[119].getFeature(es));
        }
        private static void obj21(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[125].getFeature(es));
            features.Add(allFeatureImages[126].getFeature(es));
        }
        private static void obj16(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[135].getFeature(es));
            features.Add(allFeatureImages[136].getFeature(es));
            features.Add(allFeatureImages[137].getFeature(es));
            features.Add(allFeatureImages[138].getFeature(es));
            features.Add(allFeatureImages[139].getFeature(es));
            features.Add(allFeatureImages[140].getFeature(es));
        }
        private static void obj17(Essence es, List<Feature> features)
        {
            features.Add(allFeatureImages[63].getFeature(es));
            features.Add(allFeatureImages[64].getFeature(es));
            features.Add(allFeatureImages[113].getFeature(es));
            features.Add(allFeatureImages[65].getFeature(es));
            features.Add(allFeatureImages[66].getFeature(es));
            features.Add(allFeatureImages[67].getFeature(es));
        }


    }


}
