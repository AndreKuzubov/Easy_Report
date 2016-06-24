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
using System.Text;
using System.IO;
using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public static class Exporter
    {
        //теги связанны с prepareTemplate в MDIParent1  и exportAll
        public static String TEG_TOTAL = "@total";
        public static String TEG_VICTIM = "@victim";
        public static String TEG_DRIVERS = "@drivers";
        public static String TEG_AUTO = "@auto";
        public static String TEG_SCENE = "@place";
        public static String TEG_INSPECTOR = "@inspector";
        public static String TEG_SCHOOL = "@school";


        public static void exportAll(Word.Application app, TreeNodeCollection root)
        {
            String[] tegs = new String[] { TEG_TOTAL, TEG_VICTIM, TEG_DRIVERS, TEG_AUTO, TEG_SCENE, TEG_INSPECTOR, TEG_SCHOOL };
            Object unit = WordEnums.WdUnits.wdStory;
            /* for (int i = 0; i < tegs.Length; i++)
             {
                 //ищем раставленные теги в приготовленном для нас шаблоне 
                 //( смотри установку тегов MdiParent1prepereWordTemplate() )

                 app.Selection.Find.ClearFormatting();
                 object findText = tegs[i];
                 if (app.Selection.Find.Execute( findText,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing))
                 {
                     switch (i)
                     {
                         case 0: exportTotal(app, root); break;
                         case 1: exportVictim(app, root); break;
                         case 2: exportDriver(app, root); break;
                         case 3: exportAuto(app, root); break;
                         case 4: exportScene(app, root); break;
                         case 5: exportInspector(app, root); break;
                         case 6: exportSchool(app, root); break;
                     }

                 }

                 app.Selection.MoveEnd( unit, -1);
             }*/


        }

              public static void exportTotal(Word.Application app, TreeNodeCollection root)
              {
                  app.Selection.Text = "\tОбщие Сведения.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  
                  object unit = WordEnums.WdUnits.wdLine;
                  object count = 1;
                  app.Selection.MoveStart(unit, count);


             /*     String s = "";
                  Essence eTotol = getEssence(QUESTION_GROUP.TOTAL, root);
                  List<FormQuestion> fQuestions = eTotol.getQuestionGroup(QUESTION_GROUP.TOTAL);
                  s += "Было установлено, что ";
                  if (fQuestions[2].isAnswered) {
                      DateSaver date =(DateSaver) fQuestions[2].Answer;
                      s += ((date.isDate) ? date.date.ToLongDateString()+" " : "") + ((date.isTime) ? date.time.ToLongTimeString():"");
                  }
                  if (fQuestions[3].isAnswered) s += " произошло дтп по адресу " + fQuestions[3].Answer;
                  */



           //       app.Selection.Text = s + "\n\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }
        /*
              public static void exportVictim(Word.Application app, TreeNodeCollection root)
              {
                  app.Selection.Text = "\tСведения о пострадавших.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  object unit = WordEnums.WdUnits.wdLine;
                  object count = 1;
                  app.Selection.MoveStart( unit,  count);

                  List<Essence> eVictims = getEssences(QUESTION_GROUP.VICTIM, root);
                  if (eVictims == null || eVictims.Count == 0)
                  {
                      app.Selection.Text = "Пострадавших нет\n";
                      app.Selection.Font.Bold = 0;
                      app.Selection.Font.Size = 14;
                      return;
                  }

                  String s = "";
                  foreach (Essence es in eVictims)
                  {
                      //личные данные
                      List<FormQuestion> sQuestions = es.getQuestionGroup(QUESTION_GROUP.MAN);
                      if (sQuestions[1].isAnswered) s += sQuestions[1].Answer + ".";
                      if (sQuestions[2].isAnswered)
                      {
                          DateSaver date = (DateSaver)sQuestions[2].Answer;
                          s += " Дата рождения " + (date.date.ToLongDateString()) + (!isAdult(es)?" (возраст " + (DateTime.Today - date.date).Days / 365 + " лет)":"")+".";
                      }
                      if (sQuestions[3].isAnswered) s +=" Место регистрации "+ sQuestions[3].Answer + ".";
                      if (sQuestions[4].isAnswered) s += " Место жительсва " + sQuestions[4].Answer + ".";
                      if (sQuestions[5].isAnswered && (int)sQuestions[5].Answer == 0 && !isAdult(es)) s += " Учебное заведение не посещает.";

                      //как пострадавший
                      sQuestions = es.getQuestionGroup(QUESTION_GROUP.VICTIM);
                      if (sQuestions[0].isAnswered) s += " Доставлен в "+sQuestions[0].Answer + ".";
                      if (sQuestions[1].isAnswered) s += " Диагноз: " + sQuestions[1].Answer + ".";

                      //TODO обстоятельсва 
                      //TODO пешеход
                      //TODO пассажир 
                      //TODO водитель 
                      //TODO обстоятельсва   

                  }

                  app.Selection.Text = s + "\n\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }

              public static void exportAuto(Word.Application app, TreeNodeCollection root)
              {
                  app.Selection.Text = "\tСведения о транспортных средствах.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  object unit = 5;
                  object count = 1;
                  app.Selection.MoveStart( unit,  count);

                  List<Essence> eAuto = getEssences(QUESTION_GROUP.AUTO, root);
                  if (eAuto == null || eAuto.Count == 0 || isEmty(eAuto,QUESTION_GROUP.AUTO))
                  {
                      if (eAuto.Count==1)
                          app.Selection.Text = "сведений о транспортом средстве нет, ведутся розыскные мероприятия.\n";
                      else
                          app.Selection.Text = "сведений о транспортных средствах нет, ведутся розыскные мероприятия.\n";
                      app.Selection.Font.Bold = 0;
                      app.Selection.Font.Size = 14;
                      return;
                  }


                  String s = "";
                  int i = 0;
                  foreach (Essence es in eAuto)
                  {
                      ++i;
                      List<FormQuestion> sQuestions = es.getQuestionGroup(QUESTION_GROUP.AUTO);
                      if (isEmty(sQuestions, QUESTION_GROUP.AUTO))
                      {
                          s += "" + i + "." + " Данных о транспортном средстве нет+\n\t";
                          continue;
                      }

                      if (sQuestions[1].isAnswered) s += sQuestions[1].Answer + ",";
                      if (sQuestions[2].isAnswered) s += " государственный регистрационный знак " + sQuestions[2].Answer + ",";
                      if (sQuestions[4].isAnswered) s += " владелец " + sQuestions[4].Answer + ",";
                      if (sQuestions[5].isAnswered) s += " Ф.И.О. собственника " + sQuestions[5].Answer + ",";
                      if (sQuestions[6].isAnswered) s += " зарегистрирован в " + sQuestions[6].Answer + ",";
                      if (sQuestions[7].isAnswered) s += " Полис ОСАГО " + sQuestions[7].Answer + ",";
                      if (sQuestions[8].isAnswered) s += " диагностическая карта № " + sQuestions[8].Answer + ",";
                      if (sQuestions[9].isAnswered) s += " год выпуска " + sQuestions[9].Answer + ",";
                      if (sQuestions[10].isAnswered) s += " общий пробег " + sQuestions[10].Answer + ",";

                      if (sQuestions[11].isAnswered) s += " цвет " + sQuestions[11].Answer + ",";
                      if (sQuestions[12].isAnswered) s += " тонировка " + (((int)sQuestions[12].Answer==0)? "отсутствует" : "есть") + ",";
                      if (sQuestions[13].isAnswered) s += " " + (((int)sQuestions[13].Answer == 0) ? "регистратором не оборудовано" : "регистратором оборудовано") + ",";
                      if (sQuestions[14].isAnswered) s += " пассажировместимость " + sQuestions[14].Answer + " человек,";
                      if (sQuestions[15].isAnswered) s += " грузоподьемность " + sQuestions[15].Answer + ".";
                      if (sQuestions[16].isAnswered) s += " Пассажиров на момент ДТП " + sQuestions[16].Answer + " человек.";
                      if (sQuestions[17].isAnswered) s += " Груза на момент ДТП " + sQuestions[17].Answer + "т.";
                      if (sQuestions[18].isAnswered) s += " " + sQuestions[18].Answer + ",";
                      s += "\n\t";
                  }

                  app.Selection.Text = s + "\n\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }

              public static void exportScene(Word.Application app, TreeNodeCollection root)
              {
                  Essence eScene = getEssence(QUESTION_GROUP.SCENE, root);
                  if (eScene == null)
                  {
                      app.Selection.Text = "";
                      return;
                  }
                  app.Selection.Text = "\tСведения о месте проиcшествия.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  object unit = 5;
                  object count = 1;
                  app.Selection.MoveStart( unit,  count);

                  List<FormQuestion> sQuestions = eScene.getQuestionGroup(QUESTION_GROUP.SCENE);
                  String s = "";
               //   if (sQuestions[0].isAnswered) s += "Место происшествия - " + sQuestions[0].Answer + ".\n";
                  if (sQuestions[1].isAnswered) s += "Категория дороги - " + sQuestions[1].Answer + ".\n";
                  if (sQuestions[2].isAnswered) s += "Принадлежность дороги - " + sQuestions[2].Answer + ".\n";
                  if (sQuestions[3].isAnswered) s += "Ширина дороги - " + (int)sQuestions[3].Answer + ".\n";
                  if (sQuestions[4].isAnswered) s += "Количество полос - " + (int)sQuestions[4].Answer + ".\n";
                  if (sQuestions[5].isAnswered) s += "Ширина полос - " + sQuestions[5].Answer + ".\n";
                  if (sQuestions[6].isAnswered) s += "Тип покрытия - " + sQuestions[6].Answer + ".\n";
                  if (sQuestions[7].isAnswered) s += "Состояние обочины - " + sQuestions[7].Answer + ".\n";
                  if (sQuestions[8].isAnswered) s += "Ширина обочины - " + (int)sQuestions[8].Answer + ".\n";
                  if (sQuestions[9].isAnswered) s += "Тип ограждения - " + sQuestions[9].Answer + ".\n";
                  if (sQuestions[10].isAnswered && (int)sQuestions[10].Answer == 0) s += "Участок дороги прямой по плану. \n";
                  if (sQuestions[10].isAnswered && (int)sQuestions[10].Answer == 2) s += "Участок дороги малого радиуса. \n";
                  if (sQuestions[10].isAnswered && (int)sQuestions[10].Answer == 3) s += "Участок дороги большого радиуса. \n";
                  if (sQuestions[10].isAnswered && (int)sQuestions[10].Answer == 1 && sQuestions[11].isAnswered) s += "Радиус участка дороги по плану " + (int)sQuestions[11].Answer + "м.\n";
                  if (sQuestions[12].isAnswered)
                  {
                      s += "Дорожные сооружения: ";
                      int[] a = (int[])sQuestions[12].Answer;
                      bool b = false;
                      for (int i = 0; i < a.Length; i++) if (a[i] == 1)
                          {

                              s += (b ? ", " : "") + sQuestions[12].sAnswers[i];
                              b = !b;
                          }
                      s += ".\n";
                  }
                  if (sQuestions[13].isAnswered)
                  {
                      s += "Дорожные знаки: ";
                      int[] a = (int[])sQuestions[13].Answer;
                      bool b = false;
                      for (int i = 0; i < a.Length; i++) if (a[i] == 1)
                          {

                              s += (b ? ", " : "") + sQuestions[13].sAnswers[i];
                              b = !b;
                          }
                      s += ".\n";
                  }
                  if (sQuestions[14].isAnswered) s += "Состояние дороги - " + sQuestions[14].Answer + ".\n";
                  if (sQuestions[15].isAnswered) s += "Дорожные условия - " + sQuestions[15].Answer + ".\n";
                  if (sQuestions[16].isAnswered) s += "Погодные условия - " + sQuestions[16].Answer + ".\n";
                  if (sQuestions[17].isAnswered) s += sQuestions[17].Answer + "\n";

                  app.Selection.Text = s + "\n\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }

              public static void exportInspector(Word.Application app, TreeNodeCollection root)
              {
                  Essence eInspector = getEssence(QUESTION_GROUP.INSPECTOR, root);
                  if (eInspector == null)
                  {
                      app.Selection.Text = "";
                      return;
                  }
                  app.Selection.Text = "\tСведения о прибытии на место происшествия.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  object unit = 5;
                  object count = 1;
                  app.Selection.MoveStart( unit,  count);

                  String s = "";
                  List<FormQuestion> fQuestions= eInspector.getQuestionGroup(QUESTION_GROUP.INSPECTOR);
                  if (fQuestions[0].isAnswered)
                  {
                      DateSaver date = (DateSaver)fQuestions[0].Answer;
                      if (date.isTime)
                          s += " Время прибытия ДПС " + date.time.ToShortTimeString() + ".";
                      else s += " ДПС не приезжала.";
                  }
                  else s += " ДПС не приезжала.";
                  if (fQuestions[2].isAnswered)
                  {
                      DateSaver date = (DateSaver)fQuestions[2].Answer;
                      if (date.isTime)
                          s += " Время прибытия скорой помощи " + date.time.ToShortTimeString() + ".";
                      else s += " Cкорая помощь не приезжала.";
                  }
                  else s += " Cкорая помощь не приезжала.";
                  if (fQuestions[3].isAnswered)
                  {
                      DateSaver date = (DateSaver)fQuestions[3].Answer;
                      if (date.isTime)
                          s += " Время прибытия МЧС " + date.time.ToShortTimeString() + ".";
                      else s += " МЧС не приезжала.";
                  }
                  else s += " МЧС не приезжала.";

                  if (fQuestions[1].isAnswered) s +=" "+ fQuestions[1].Answer+".";
                  if (fQuestions[4].isAnswered) s += " " + fQuestions[4].Answer + ".";

                  app.Selection.Text = s+"\n\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }

              public static void exportDriver(Word.Application app, TreeNodeCollection root)
              {
                  app.Selection.Text = "\tСведения о водителях.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  object unit = 5;
                  object count = 1;
                  app.Selection.MoveStart( unit,  count);

                  List<Essence> eDriver = getEssences(QUESTION_GROUP.DRIVER, root);
                  if (eDriver == null || eDriver.Count == 0 || isEmty(eDriver, QUESTION_GROUP.DRIVER))
                  {
                      if (eDriver.Count == 1)
                          app.Selection.Text = "сведений о водителе нет, ведутся розыскные мероприятия.\n";
                      else
                          app.Selection.Text = "сведений о водителях средствах нет, ведутся розыскные мероприятия.\n";
                      app.Selection.Font.Bold = 0;
                      app.Selection.Font.Size = 14;
                      return;
                  }

                  String s = "";
                  int len = eDriver.Count;
                  List<FormQuestion> sQuestions;
                  Essence es;
                  for (int i=0;i< len; i++)
                  {
                      es = eDriver[i];
                      sQuestions = ((Essence)es.Parent).getQuestionGroup(QUESTION_GROUP.AUTO);
                      s += ""+(i+1)+". ";
                      //тс
                      if (sQuestions[1].isAnswered) s += sQuestions[1].Answer + ",";
                      if (sQuestions[2].isAnswered) s += " государственный регистрационный знак " + sQuestions[2].Answer + ",";
                      //личные данные
                      sQuestions = es.getQuestionGroup(QUESTION_GROUP.MAN);
                      if (sQuestions[1].isAnswered) s += " "+sQuestions[1].Answer + ".";
                      if (sQuestions[2].isAnswered)
                      {
                          DateSaver date = (DateSaver)sQuestions[2].Answer;
                          s += " Дата рождения " + (date.date.ToLongDateString()) + (!isAdult(es) ? " (возраст " + (DateTime.Today - date.date).Days / 365 + " лет)" : "") + ".";
                      }
                      if (sQuestions[3].isAnswered) s += " Место регистрации " + sQuestions[3].Answer + ".";
                      if (sQuestions[4].isAnswered) s += " Место жительсва " + sQuestions[4].Answer + ".";
                      if (sQuestions[5].isAnswered && (int)sQuestions[5].Answer == 0 && !isAdult(es)) s += " Учебное заведение не посещает.";
                      //данные как водителя 
                      sQuestions = es.getQuestionGroup(QUESTION_GROUP.DRIVER);
                      if (sQuestions[0].isAnswered) s += " Водительского удостоверение " + sQuestions[0].Answer ;
                      if (sQuestions[1].isAnswered)
                      {
                          if (sQuestions[0].isAnswered)
                          s += " категория <<" + sQuestions[1].Answer + ">>,";
                          else s += " Категория водительского удостоверения <<" + sQuestions[1] + ">>,";
                      }
                      if (sQuestions[2].isAnswered)
                      {
                          DateSaver date =(DateSaver) sQuestions[2].Answer;
                          if (date.isDate)
                          s += " дата выдачи " + date.date.ToLongDateString()+".";
                      }
                      if (sQuestions[3].isAnswered) s += " Место выдачи " + sQuestions[3].Answer+".";
                      if (sQuestions[4].isAnswered) s += " Общий стаж вождения " + sQuestions[4].Answer+".";
                      if (sQuestions[5].isAnswered)
                      {
                          DateSaver date = (DateSaver)sQuestions[5].Answer;
                          if (date.isDate)
                              s += " Дата медицинского осведетельсвования " + date.date.ToLongDateString() + "  ";
                          if (date.isTime)
                              s += date.time.ToLongTimeString();
                     //     s+= ".";
                      }
            //          s += "\n\t";
                      if (sQuestions[6].isAnswered) s += ((int)sQuestions[6].Answer == 0) ?" Предрейсовый осмотр не проходил.":" Предрейсовый осмотр прошел.";
                      if (sQuestions[7].isAnswered) s += ((int)sQuestions[7].Answer == 0) ? " Родители не знали, что ребенок был за рулем."  : " Родители знали, что ребенок был за рулем.";
                      if (sQuestions[8].isAnswered) s += " Дтп произошло в "+sQuestions[8].Answer +" часу управления.";
                      if (sQuestions[9].isAnswered) s += " "+sQuestions[9].Answer + ".";


                  }


                  app.Selection.Text = s+"\n\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }

              public static void exportSchool(Word.Application app,TreeNodeCollection root)
              {
                  app.Selection.Text = "\tСведения об образовательном учреждении.";
                  app.Selection.Font.Bold = 1;
                  app.Selection.Font.Size = 14;
                  object unit = 5;
                  object count = 1;
                  app.Selection.MoveStart(unit, count);

                  List<Essence> eSchool = getEssences(QUESTION_GROUP.SCHOOL, root);
                  if (eSchool == null || eSchool.Count == 0 || isEmty(eSchool, QUESTION_GROUP.SCHOOL))
                  {
                      if (eSchool.Count == 1)
                          app.Selection.Text = "";
                      else
                          app.Selection.Text = "";
                      app.Selection.Font.Bold = 0;
                      app.Selection.Font.Size = 14;
                      return;
                  }

                  String s = "";
                  int len = eSchool.Count;
                  List<FormQuestion> sQuestions;
                  Essence es;
                  for (int i = 0; i < len; i++)
                  {
                      es = eSchool[i];
                      sQuestions = es.getQuestionGroup(QUESTION_GROUP.SCHOOL);

                      if (sQuestions[0].isAnswered) s += sQuestions[0].Answer;
                      if (sQuestions[1].isAnswered) s += " расположена по адресу "+sQuestions[1].Answer;
                      s += ".";
                      if (sQuestions[2].isAnswered) s += " Директор школы " + sQuestions[2].Answer + ".";
                      if (sQuestions[3].isAnswered) s += " Ответственный по предупреждению детского травматизма " + sQuestions[3].Answer+".";
                      if (sQuestions[4].isAnswered) s += " Заместитель по воспитательной работе " + sQuestions[4].Answer+".";
                      if (sQuestions[5].isAnswered) s += " " + sQuestions[5].Answer;

                      s += "\n\t";
                  }



                      app.Selection.Text = s+"\n";
                  app.Selection.Font.Bold = 0;
                  app.Selection.Font.Size = 14;
              }

              private static Essence getEssence(QUESTION_GROUP gr, TreeNodeCollection root)
              {
                  int len = root.Count;
                  for (int i = 0; i < len; i++)
                  {
                      if (((Essence)root[i]).fQuestions.ContainsKey(gr)) return (Essence)root[i];
                  }
                  return null;
              }

              private static List<Essence> getEssences(QUESTION_GROUP gr, TreeNodeCollection root)
              {
                  List<Essence> es = new List<Essence>();
                  int len = root.Count;
                  for (int i = 0; i < len; i++)
                  {
                      if (root[i].Nodes != null && root[i].Nodes.Count > 0)
                      {
                          List<Essence> ies = getEssences(gr, root[i].Nodes);
                          if (ies != null && ies.Count > 0) es.AddRange(ies);
                      }
                      if (((Essence)root[i]).fQuestions.ContainsKey(gr)) es.Add((Essence)root[i]);
                  }
                  return es;

              }

              private static bool isAdult(Essence es)
              {
                  return false;// FormQuestionsTemplates.isAdult(ref es);
              }

              private static bool isEmty(List<Essence> es,QUESTION_GROUP gr)
              {
                  foreach (Essence e in es)
                  {
                      List<FormQuestion> fQuestions = e.getQuestionGroup(gr);
                      foreach (FormQuestion fq in fQuestions)
                      if (fq.isAnswered) return false;
                  }
                  return true;
              }

              private static bool isEmty(List<FormQuestion> fQuestions, QUESTION_GROUP gr)
              {
                  foreach (FormQuestion fq in fQuestions)
                      if (fq.isAnswered) return false;
                  return false;
              }

          }*/
    }

}
