
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
                using System.Text;
                using System.IO;
                using Word = NetOffice.WordApi;
                using WordEnums = NetOffice.WordApi.Enums;
                using System.Windows.Forms;
                using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
    {
        public static class Exporter
        {




            public static void exportAll(String filename)
            {
                 List<DBTemplatesHelper.DBParagraph> paragraphs = new List<DBTemplatesHelper.DBParagraph>();

paragraphs.Add(new DBTemplatesHelper.DBParagraph(1,1,@"{\rtf1\ansi\ansicpg1251\deff0\nouicompat\deflang1049{\fonttbl{\f0\froman\fprq2\fcharset204{\*\fname Times New Roman;}Times New Roman CYR;}{\f1\fmodern\fprq1\fcharset204{\*\fname Courier New;}Courier New CYR;}{\f2\fmodern\fprq1\fcharset0 Courier New;}{\f3\fnil\fcharset204 Microsoft Sans Serif;}}
{\colortbl ;\red0\green0\blue0;}
{\*\generator Riched20 10.0.10586}\viewkind4\uc1 
\pard\widctlpar\qc\f0\fs28                                \par
\b\par

\pard\widctlpar\b0\par

\pard\widctlpar\qc\b\'c7\'c0\'ca\'cb\'de\'d7\'c5\'cd\'c8\'c5\par
\'ef\'ee \'f0\'e5\'e7\'f3\'eb\'fc\'f2\'e0\'f2\'e0\'ec \'ef\'f0\'ee\'e2\'e5\'e4\'e5\'ed\'e8\'ff \'ef\'f0\'ee\'e2\'e5\'f0\'ea\'e8 \par
\'ef\'ee \'f4\'e0\'ea\'f2\'f3 \'c4\'d2\'cf \'f1 \'f3\'f7\'e0\'f1\'f2\'e8\'e5\'ec \'ed\'e5\'f1\'ee\'e2\'e5\'f0\'f8\'e5\'ed\'ed\'ee\'eb\'e5\'f2\'ed\'e5\'e3\'ee.\par
\b0\par

\pard\widctlpar\fi709\qj\b\f1\'ce\'e1\'f9\'e8\'e5 \'f1\'e2\'e5\'e4\'e5\'ed\'e8\'ff\f0\par
\cf1\b0\protect (SRIPT15)\protect0\par
\cf0\b\f1\par
\'d1\'e2\'e5\'e4\'e5\'ed\'e8\'ff \'ee \'ef\'ee\'f1\'f2\'f0\'e0\'e4\'e0\'e2\'f8\'e8\'f5:\par
\protect (SRIPT14)\protect0\par
\b0\fs20\par

\pard\widctlpar\fi708\qj\fs28  \par
\b\'d1\'e2\'e5\'e4\'e5\'ed\'e8\'ff \'ee \'e2\'ee\'e4\'e8\'f2\'e5\'eb\'e5 \'f2\'f0\'e0\'ed\'f1\'ef\'ee\'f0\'f2\'ed\'ee\'e3\'ee \'f1\'f0\'e5\'e4\'f1\'f2\'e2\'e0.\par
\protect (SRIPT12)\b0\protect0\fs20\par

\pard\widctlpar\fi709\qj\b\fs28\par
\'d1\'e2\'e5\'e4\'e5\'ed\'e8\'ff \'ee \'f2\'f0\'e0\'ed\'f1\'ef\'ee\'f0\'f2\'ed\'fb\'f5 \'f1\'f0\'e5\'e4\'f1\'f2\'e2\'e0\'f5.\par
\protect (SRIPT11)\protect0\par
\par
\'d1\'e2\'e5\'e4\'e5\'ed\'e8\'ff \'ee \'e4\'ee\'f0\'ee\'e6\'ed\'fb\'f5 \'f3\'f1\'eb\'ee\'e2\'e8\'ff\'f5.                                                     \b0\fs20\par

\pard\widctlpar\qj\f2\lang1033\tab\protect (SRIPT9)\b\protect0\f1\fs28\lang1049\par

\pard\widctlpar\fi709\qj\par
\'c8\'ed\'f4\'ee\'f0\'ec\'e0\'f6\'e8\'ff \'ee\'e1 \'ee\'e1\'f0\'e0\'e7\'ee\'e2\'e0\'f2\'e5\'eb\'fc\'ed\'ee\'ec \'f3\'f7\'f0\'e5\'e6\'e4\'e5\'ed\'e8\'e8.\par
\protect (SRIPT13)\protect0\par
\b0\par
\b\'d1\'e2\'e5\'e4\'e5\'ed\'e8\'ff \'ee \'ef\'f0\'e8\'e1\'fb\'f2\'e8\'e8 \'ed\'e0 \'ec\'e5\'f1\'f2\'ee \'ef\'f0\'ee\'e8\'f1\'f8\'e5\'f1\'f2\'e2\'e8\'ff.\par
\protect (SRIPT10)\b0\protect0\f3\fs17\par

\pard\par
\par
}
"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(8,0,@"return "+"\""+@"df"+"\""+@";"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(9,0,@"String s = "+"\""+@""+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(6)[0].answer != null)
s+="+"\""+@" Тип покрытия - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(6)[0].answer.sAnswer+"+"\""+@".\n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(7 )[0].answer != null)
s+="+"\""+@" Видимость - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(7)[0].answer.sAnswer+"+"\""+@".\n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(8 )[0].answer != null)
{
     if ( DataProject.getEssencesByImage(5)[0].getFeatureByImage(8)[0].answer.intAnswer == 0 )
        s+="+"\""+@" Проезжая часть прямая в плане."+"\""+@";
     if ( DataProject.getEssencesByImage(5)[0].getFeatureByImage(8)[0].answer.intAnswer == 2 )
        s+="+"\""+@" Участок проезжей части большого радиуса."+"\""+@";
     if ( DataProject.getEssencesByImage(5)[0].getFeatureByImage(8)[0].answer.intAnswer == 3 )
        s+="+"\""+@" Участок проезжей части малого радиуса."+"\""+@";
     if ( DataProject.getEssencesByImage(5)[0].getFeatureByImage(8)[0].answer.intAnswer == 1 )
       if ( DataProject.getEssencesByImage(5)[0].getFeatureByImage(9)[0].answer != null )
        s+="+"\""+@" Радиус кривизны ПС - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(9)[0].answer.sAnswer+"+"\""+@" м."+"\""+@" ; 
}

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(10 )[0].answer != null)
s+="+"\""+@" Состояние проезжей части - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(10)[0].answer.sAnswer+"+"\""+@".\n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(11 )[0].answer != null)
s+="+"\""+@" Дорожные сооружения: "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(11)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(12 )[0].answer != null)
s+="+"\""+@" Дорожные знаки: "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(12)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(14)[0].answer != null)
s+="+"\""+@" Дорожная разметка: "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(14)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";


if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(112 )[0].answer != null)
s+="+"\""+@" Наличие пешеходных дорожек, тротуаров и т.д. -  "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(112)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(15 )[0].answer != null)
s+="+"\""+@" Установленное ограничение скорости на данном УДС - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(15)[0].answer.sAnswer+"+"\""+@".\n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(16 )[0].answer != null)
s+="+"\""+@" Эксплуатационное состояние ПС - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(16)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(17 )[0].answer != null)
s+="+"\""+@" Состояние обочины - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(17)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(18 )[0].answer != null)
s+="+"\""+@" Ширина обочины - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(18)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(19 )[0].answer != null)
s+="+"\""+@" Тип ограждения - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(19)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(21 )[0].answer != null)
s+="+"\""+@" Тип освещения - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(21)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(22 )[0].answer != null)
s+="+"\""+@" Регулирование движения - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(22)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(23 )[0].answer != null)
s+="+"\""+@" Время суток - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(23)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(24 )[0].answer != null)
s+="+"\""+@" Дорожные условия - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(24)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(25 )[0].answer != null)
s+="+"\""+@" Погодные условия- "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(25)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(26 )[0].answer != null)
s+="+"\""+@" Принадлежность ПС - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(26)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer != null)
s+="+"\""+@" Количество полос в 1 сторону - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(27)[0].answer.sAnswer+"+"\""+@".  \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(28)[0].answer != null)
s+="+"\""+@" Количество полос в встречного направления - "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(28)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";

if (  DataProject.getEssencesByImage(5)[0].getFeatureByImage(53)[0].answer != null)
s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(5)[0].getFeatureByImage(53)[0].answer.sAnswer+"+"\""+@". \n"+"\""+@";


return s;"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(10,0,@"String s="+"\""+@""+"\""+@";
if (DataProject.getEssencesByImage(17)[0].getFeatureByImage(64)[0].answer!=null)
{
   s+="+"\""+@" Наряд ДПС на время ДТП был - "+"\""+@"+DataProject.getEssencesByImage(17)[0].getFeatureByImage(64)[0].answer.sAnswer;

if ( DataProject.getEssencesByImage(17)[0].getFeatureByImage(113)[0].answer!=null)
{
   if ( DataProject.getEssencesByImage(113)[0].getFeatureByImage(64)[0].answer.intAnswer == 1)
{
    s+="+"\""+@", соответсвует указаниям дежурной части"+"\""+@";
}else {
    s+="+"\""+@", не соответсвует указаниям дежурной части"+"\""+@";
}   
}
s+="+"\""+@"."+"\""+@";
} 

if ( DataProject.getEssencesByImage(17)[0].getFeatureByImage(63)[0].answer!=null)
   s+="+"\""+@" На место ДТП наряд ДПС прибыл - "+"\""+@"+DataProject.getEssencesByImage(17)[0].getFeatureByImage(63)[0].answer.sAnswer+"+"\""+@"."+"\""+@";


if ( DataProject.getEssencesByImage(17)[0].getFeatureByImage(65 )[0].answer!=null)
   s+="+"\""+@" Бригада Скорой помощи прибыла - "+"\""+@"+DataProject.getEssencesByImage(17)[0].getFeatureByImage(65)[0].answer.sAnswer+"+"\""+@"."+"\""+@";
else 
   s+="+"\""+@" Бригада Скорой помощи не вызывалась."+"\""+@"; 


if ( DataProject.getEssencesByImage(17)[0].getFeatureByImage(66 )[0].answer!=null)
   s+="+"\""+@" Время прибытия МЧС - "+"\""+@"+DataProject.getEssencesByImage(17)[0].getFeatureByImage(66)[0].answer.sAnswer+"+"\""+@"."+"\""+@";
 
if ( DataProject.getEssencesByImage(17)[0].getFeatureByImage(67 )[0].answer!=null)
   s+=DataProject.getEssencesByImage(17)[0].getFeatureByImage(67)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

return s;"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(11,0,@"int len = DataProject.getEssencesByImage(18).Count;
String s = "+"\""+@""+"\""+@";
for (int i=0;i<len;i++){
  if (DataProject.getEssencesByImage(18)[i].getFeatureByImage(73)[0].answer!=null) 
       s+= DataProject.getEssencesByImage(18)[i].getFeatureByImage(73)[0].answer.sAnswer;
  if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(74)[0].answer!=null) 
       s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(74)[0].answer.sAnswer;
s+="+"\""+@","+"\""+@";

  if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(75)[0].answer!=null) 
       s+="+"\""+@" Государственный регистрационный знак "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(75)[0].answer.sAnswer;
s+="+"\""+@"."+"\""+@";

  if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(70 )[0].answer!=null) 
  {
          if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(70 )[0].answer.intAnswer==0 )
         {
               s+="+"\""+@" ТС принадлежит Юр. лицу "+"\""+@"; 
               if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(71)[0].answer!=null  )
                      s+="+"\""+@" "+"\""+@" +DataProject.getEssencesByImage(18)[i].getFeatureByImage(71)[0].answer.sAnswer;
               s+="+"\""+@"."+"\""+@";
          }
         if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(70 )[0].answer.intAnswer==1)
         {
               s+="+"\""+@" ТС принадлежит ИП "+"\""+@"; 
               if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(71)[0].answer!=null  )
                      s+="+"\""+@" "+"\""+@" +DataProject.getEssencesByImage(18)[i].getFeatureByImage(71)[0].answer.sAnswer;
               s+="+"\""+@"."+"\""+@";
          }
          if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(70 )[0].answer.intAnswer==2)
         {
               if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer!=null  )
               {
                      s+="+"\""+@" Собственник ТС"+"\""+@"; 
                    if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer.eAnswer.getFeatureByImage(92)[0].answer!=null) 
                    {
                        s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer.eAnswer.getFeatureByImage(92)[0].answer.sAnswer+"+"\""+@"."+"\""+@"; 
                     }

                    if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer.eAnswer.getFeatureByImage(93)[0].answer!=null) 
                    {
                        s+="+"\""+@" Дата рождения "+"\""+@"+ DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer.eAnswer.getFeatureByImage(93)[0].answer.sAnswer+"+"\""+@"."+"\""+@"; 
                     }
                      

              
                      if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer.eAnswer.getFeatureByImage(94 )[0].answer!=null) 
                    {
                        s+="+"\""+@" Зарегестрирован по адресу "+"\""+@"+ DataProject.getEssencesByImage(18)[i].getFeatureByImage(72)[0].answer.eAnswer.getFeatureByImage(94)[0].answer.sAnswer+"+"\""+@"."+"\""+@"; 
                     }

                                   
               }
          }


 
   }


  if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(76)[0].answer!=null) 
       s+="+"\""+@" Осаго "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(76)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(77)[0].answer!=null) 
       s+="+"\""+@" Vin номер "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(77)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(78)[0].answer!=null) 
       s+="+"\""+@" Номер кузова "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(78)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(79)[0].answer!=null) 
       s+="+"\""+@" Год выпуска"+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(79)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(80)[0].answer!=null) 
       s+="+"\""+@" Год выпуска"+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(80)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(81 )[0].answer!=null) 
       s+="+"\""+@" Дата проведения тех обслуживания "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(81)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(83 )[0].answer!=null) 
       s+="+"\""+@" Цвет "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(83)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(84 )[0].answer!=null) 
       s+="+"\""+@" Тонировка передней полусферы "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(84)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

 if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(85 )[0].answer!=null) 
       s+="+"\""+@" Видеорегистратор "+"\""+@"+((DataProject.getEssencesByImage(18)[i].getFeatureByImage(85)[0].answer.intAnswer==1)?"+"\""+@"установлен"+"\""+@":"+"\""+@"отсутствовал"+"\""+@")+"+"\""+@"."+"\""+@";

if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(86 )[0].answer!=null) 
       s+="+"\""+@" Пассажировместимость "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(86)[0].answer.sAnswer +"+"\""+@" человек."+"\""+@";

if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(87 )[0].answer!=null) 
       s+="+"\""+@" На момент ДТП пассажиров было в машине "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(87)[0].answer.sAnswer +"+"\""+@" человек."+"\""+@";

if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(88 )[0].answer!=null) 
       s+="+"\""+@" Грузоподьемность "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(88)[0].answer.sAnswer +"+"\""+@" тонн."+"\""+@";

if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(89 )[0].answer!=null) 
       s+="+"\""+@" Груза на момент ДТП "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(89)[0].answer.sAnswer +"+"\""+@" тонн."+"\""+@";

if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(90 )[0].answer!=null) 
       s+="+"\""+@" Стоянка ТС по адресу "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(90)[0].answer.sAnswer +"+"\""+@"."+"\""+@";

if ( DataProject.getEssencesByImage(18)[i].getFeatureByImage(91 )[0].answer!=null) 
       s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(18)[i].getFeatureByImage(91)[0].answer.sAnswer +"+"\""+@"."+"\""+@";

  s+="+"\""+@"\n"+"\""+@";
}
return s;"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(12,0,@"int len = DataProject.getEssencesByImage(22).Count;
String s="+"\""+@""+"\""+@";
for (int i=0;i<len;i++)
{
   //его ТС 
   if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer!=null )
   { 
         s+= "+"\""+@" Водитель машины "+"\""+@";
         if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(73)[0].answer!=null  )
              s+=DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(73)[0].answer.sAnswer;  
        
         if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(74)[0].answer!=null  )
              s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(74)[0].answer.sAnswer;
         s+="+"\""+@","+"\""+@";  
        
         if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(75)[0].answer!=null  )
              s+="+"\""+@" государственный регистрационный знак "+"\""+@"+DataProject.getEssencesByImage(22)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(75)[0].answer.sAnswer+"+"\""+@","+"\""+@";  

   } 
 
  if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(92)[0].answer!=null )
    s+= DataProject.getEssencesByImage(22)[i].getFeatureByImage(92)[0].answer.sAnswer;

  if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(93)[0].answer!=null )
    s+="+"\""+@", дата рождения "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(93)[0].answer.sAnswer;
  s+="+"\""+@"."+"\""+@";
  
  if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(94)[0].answer!=null )
    s+="+"\""+@" Адрес регистрации "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(94)[0].answer.sAnswer+"+"\""+@"."+"\""+@";  
   
  if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(95)[0].answer!=null )
    s+="+"\""+@" Адрес проживания "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(95)[0].answer.sAnswer+"+"\""+@"."+"\""+@";    

  if ( DataProject.getEssencesByImage(22)[i].hasEssence(12) )
  {
        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(127)[0].answer!=null )
            s+="+"\""+@"  Категория водительских прав "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(127)[0].answer.sAnswer+"+"\""+@"."+"\""+@";    
      
        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(128)[0].answer!=null )
            s+="+"\""+@" Дата выдачи"+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(128)[0].answer.sAnswer+"+"\""+@"."+"\""+@";   

        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(130)[0].answer!=null )
            s+="+"\""+@" Общий стаж вождения "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(130)[0].answer.sAnswer+"+"\""+@"."+"\""+@";   

        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(131)[0].answer!=null )
            s+="+"\""+@" Стаж вождения данной категории "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(1317)[0].answer.sAnswer+"+"\""+@"."+"\""+@";   


        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(132)[0].answer!=null )
            s+="+"\""+@" Дата последнего освидетельствония "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(132)[0].answer.sAnswer+"+"\""+@"."+"\""+@";   

        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(133)[0].answer!=null)
            s+=((DataProject.getEssencesByImage(22)[i].getFeatureByImage(133)[0].answer.intAnswer==1)?"+"\""+@" Предрейсовый осмотр проходил."+"\""+@":"+"\""+@" Предрейсового осмотра не было"+"\""+@"); 

  }


   if ( DataProject.getEssencesByImage(22)[i].hasEssence(19) )
  {
      if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(120)[0].answer!=null )
            s+=((DataProject.getEssencesByImage(22)[i].getFeatureByImage(120)[0].answer.intAnswer==1)?"+"\""+@" У водителя есть документы на управление данным ТС"+"\""+@":"+"\""+@" У водителя отсутствуют документы, разрешающие управлять ТС"+"\""+@")+"+"\""+@"."+"\""+@";    
      
     if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(121)[0].answer!=null )
            s+="+"\""+@" Несовершеннолетний оказался за рулем: "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(121)[0].answer.sAnswer+"+"\""+@"."+"\""+@";   

       if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(122)[0].answer!=null )
            s+= ((DataProject.getEssencesByImage(22)[i].getFeatureByImage(122)[0].answer.intAnswer==1)?"+"\""+@" Родителям было известно о поступке ребенка"+"\""+@":"+"\""+@" Родителям не было известно о поступке ребенка"+"\""+@")+"+"\""+@"."+"\""+@";   

       if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(123)[0].answer!=null )
            s+= ((DataProject.getEssencesByImage(22)[i].getFeatureByImage(123)[0].answer.intAnswer==1)?"+"\""+@" Родители не привлекались к административной ответственности"+"\""+@":"+"\""+@" Родители уже привлекались к административной ответственности"+"\""+@")+"+"\""+@"."+"\""+@";   

  }


   if ( DataProject.getEssencesByImage(22)[i].hasEssence(15) )
  {
        if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(110)[0].answer!=null )
            s+="+"\""+@" Сопровождающие на момент ДТП "+"\""+@"+DataProject.getEssencesByImage(22)[i].getFeatureByImage(110)[0].answer.sAnswer+"+"\""+@"."+"\""+@";    
     
  }

   if ( DataProject.getEssencesByImage(22)[i].getFeatureByImage(142)[0].answer!=null )
            s+="+"\""+@" ДТП произошло в "+"\""+@"+ DataProject.getEssencesByImage(22)[i].getFeatureByImage(142)[0].answer.sAnswer+"+"\""+@" часу."+"\""+@";   


   s+="+"\""+@"\n"+"\""+@";
}

return s;"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(13,0,@"int len = DataProject.getEssencesByImage(15).Count;
String s="+"\""+@""+"\""+@";
for (int i=0;i<len;i++)
{
    if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(92)[0].answer!=null)
       s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(15)[i].getFeatureByImage(92)[0].answer.sAnswer;
    if (  DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer==null)
        s+="+"\""+@" является неорганизованным"+"\""+@";
    else 
    {
          s+="+"\""+@" посещает"+"\""+@";
           if (  DataProject.getEssencesByImage(15)[i].getFeatureByImage(98)[0].answer!=null)
                  s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(15)[i].getFeatureByImage(98)[0].answer.sAnswer+"+"\""+@" класс"+"\""+@";

         if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(135)[0].answer!=null)
                s+= DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(135)[0].answer.sAnswer;

        if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(136)[0].answer!=null)
                s+="+"\""+@" по адресу "+"\""+@"+ DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(136)[0].answer.sAnswer;

        s+="+"\""+@"."+"\""+@";
        

        if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(137)[0].answer!=null)
                s+="+"\""+@" Директор "+"\""+@" +DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(137)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

       if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(138)[0].answer!=null)
                s+="+"\""+@" Ответственный по предупреждению детского травматизма"+"\""+@"+ DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(137)[0].answer.sAnswer+"+"\""+@"."+"\""+@";


       if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(138)[0].answer!=null)
                s+="+"\""+@" Заместитель по воспитательной работе"+"\""+@"+ DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(137)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

       if ( DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(140)[0].answer!=null)
                s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(15)[i].getFeatureByImage(97)[0].answer.eAnswer.getFeatureByImage(140)[0].answer.sAnswer+"+"\""+@"."+"\""+@";
    }

   s+="+"\""+@"\n"+"\""+@";
}
return s;"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(14,0,@"int len = DataProject.getEssencesByImage(11).Count;
String s = "+"\""+@""+"\""+@";
for (int i=0;i<len;i++)
{

        if ( DataProject.getEssencesByImage(11)[i].hasEssence(22) )
        {  
             s+="+"\""+@" Водитель"+"\""+@";
             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer!=null )
            {  
                    if (  DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(61)[0].answer != null)
                           s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(61)[0].answer.sAnswer;

                    if (  DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(62)[0].answer != null)
                           s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(62)[0].answer.sAnswer;

                    if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.hasEssence(18)!=null )
                   {                   
                             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(73)[0].answer!=null )
                                  s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(73)[0].answer.sAnswer;
                             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(74)[0].answer!=null )
                                  s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(74)[0].answer.sAnswer;

                             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(75)[0].answer!=null )
                                 s+="+"\""+@" государственный регистрационный номер "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(75)[0].answer.sAnswer;
                    }


             }  

             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(92)[0].answer!=null)
                 s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(92)[0].answer;
             s+="+"\""+@"."+"\""+@";
                       
            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(93)[0].answer!=null)
                s+="+"\""+@" Дата рождения "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(93)[0].answer+"+"\""+@"."+"\""+@";
 
            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(94)[0].answer!=null)
                s+="+"\""+@" Адрес регистрации "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(94)[0].answer+"+"\""+@"."+"\""+@";

            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(95)[0].answer!=null)
                s+="+"\""+@" Адрес проживания "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(95)[0].answer+"+"\""+@"."+"\""+@";       


            if ( DataProject.getEssencesByImage(11)[i].hasEssence(15) )
            {
                   if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer != null  )
                        s+="+"\""+@" Сопровождающие на момент ДТП"+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer.sAnswer + "+"\""+@"."+"\""+@";
            }

             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer!=null )
            {  
                    if (  DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(108)[0].answer != null)
                           s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(108)[0].answer.sAnswer+"+"\""+@"."+"\""+@";               
             }

        }









        if ( DataProject.getEssencesByImage(11)[i].hasEssence(13) )
        {   
 
             s+="+"\""+@" Пассажир"+"\""+@";
             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer!=null )
            {  
                    s+= "+"\""+@" автомашины"+"\""+@";
                     if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(73)[0].answer!=null )
                         s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(73)[0].answer.sAnswer;
                      if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(74)[0].answer!=null )
                          s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(74)[0].answer.sAnswer;

                      if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(75)[0].answer!=null )
                          s+="+"\""+@" государственный регистрационный номер "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(104)[0].answer.eAnswer.getFeatureByImage(75)[0].answer.sAnswer;
             }  

             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(92)[0].answer!=null)
                 s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(92)[0].answer;
             s+="+"\""+@"."+"\""+@";
                       
            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(93)[0].answer!=null)
                s+="+"\""+@" Дата рождения "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(93)[0].answer+"+"\""+@"."+"\""+@";
 
            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(94)[0].answer!=null)
                s+="+"\""+@" Адрес регистрации "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(94)[0].answer+"+"\""+@"."+"\""+@";

            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(95)[0].answer!=null)
                s+="+"\""+@" Адрес проживания "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(95)[0].answer+"+"\""+@"."+"\""+@";       


            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(124)[0].answer != null  )
                s+="+"\""+@" Место в машине"+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(124)[0].answer.sAnswer + "+"\""+@"."+"\""+@";

            if ( DataProject.getEssencesByImage(11)[i].hasEssence(15) )
            {
                   if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer != null  )
                        s+="+"\""+@" Сопровождающие на момент ДТП"+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer.sAnswer + "+"\""+@"."+"\""+@";
 
                   if ( DataProject.getEssencesByImage(11)[i].hasEssence(21) )
                  {
                          if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(125)[0].answer != null  )
                                 s+= ((DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer.intAnswer==1)?"+"\""+@" Был закреплен детским удерживающим устройством"+"\""+@":"+"\""+@" Не был закреплен детским удерживающим устройством"+"\""+@") + "+"\""+@"."+"\""+@";

                         if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(126)[0].answer != null  )
                                s+="+"\""+@" Водитель для ребенка - "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(126)[0].answer.sAnswer + "+"\""+@"."+"\""+@";

                  }
            }

        }









        if ( DataProject.getEssencesByImage(11)[i].hasEssence(14) )
        {  
             s+="+"\""+@" Пешеход"+"\""+@";

             if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(92)[0].answer!=null)
                 s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(92)[0].answer;
             s+="+"\""+@"."+"\""+@";
                       
            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(93)[0].answer!=null)
                s+="+"\""+@" Дата рождения "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(93)[0].answer+"+"\""+@"."+"\""+@";
 
            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(94)[0].answer!=null)
                s+="+"\""+@" Адрес регистрации "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(94)[0].answer+"+"\""+@"."+"\""+@";

            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(95)[0].answer!=null)
                s+="+"\""+@" Адрес проживания "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(95)[0].answer+"+"\""+@"."+"\""+@";      

            if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(109)[0].answer!=null)
                s+="+"\""+@" Место совершения наезда "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(109)[0].answer.sAnswer+"+"\""+@"."+"\""+@";
 
           if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(106)[0].answer!=null)
                s+="+"\""+@" Цветовая гамма одежды "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(106)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

           if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(107)[0].answer!=null)
                s+="+"\""+@" Светоотражающие элементы "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(107)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

            if ( DataProject.getEssencesByImage(11)[i].hasEssence(15) )
            {
                   if ( DataProject.getEssencesByImage(11)[i].hasEssence(20) )
                  {
                        if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(117)[0].answer!=null)
                            s+="+"\""+@" Направление движения "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(117)[0].answer.sAnswer+"+"\""+@"."+"\""+@";

                       if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(118)[0].answer!=null)
                           s+="+"\""+@" Маршрут движения "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(118)[0].answer.sAnswer+"+"\""+@"."+"\""+@";
                     
                       if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(119)[0].answer!=null)
                           s+="+"\""+@" Отдаленность от образовательного учреждения, дома и т.д -  "+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(119)[0].answer.sAnswer+"+"\""+@"."+"\""+@";                       

                   }
                   if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer != null  )
                        s+="+"\""+@" Сопровождающие на момент ДТП"+"\""+@"+DataProject.getEssencesByImage(11)[i].getFeatureByImage(110)[0].answer.sAnswer + "+"\""+@"."+"\""+@";
            }
            



        }

   
    if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(99)[0].answer!=null)
   s+="+"\""+@" Характер травм - "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(99)[0].answer+"+"\""+@"."+"\""+@";

  if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(100)[0].answer!=null)
   s+="+"\""+@" Тяжесть травм - "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(100)[0].answer+"+"\""+@"."+"\""+@";

  if ( DataProject.getEssencesByImage(11)[i].getFeatureByImage(101)[0].answer!=null)
   s+="+"\""+@" "+"\""+@"+ DataProject.getEssencesByImage(11)[i].getFeatureByImage(101)[0].answer+"+"\""+@"."+"\""+@";

 s +="+"\""+@"\n"+"\""+@";
}

return s;
"));
 paragraphs.Add(new DBTemplatesHelper.DBParagraph(15,0,@"String s="+"\""+@""+"\""+@";
 if ( DataProject.getEssencesByImage(4)[0].getFeatureByImage(56)[0].answer!=null)
   s+=DataProject.getEssencesByImage(4)[0].getFeatureByImage(56)[0].answer.sAnswer;

 if ( DataProject.getEssencesByImage(4)[0].getFeatureByImage(105)[0].answer!=null)
   s+="+"\""+@" по адресу "+"\""+@"+DataProject.getEssencesByImage(4)[0].getFeatureByImage(105)[0].answer.sAnswer;

s+= "+"\""+@" произошло ДТП."+"\""+@";

 if ( DataProject.getEssencesByImage(4)[0].getFeatureByImage(58)[0].answer!=null)
   s+="+"\""+@" "+"\""+@"+DataProject.getEssencesByImage(4)[0].getFeatureByImage(58)[0].answer.sAnswer;

return s;"));
 

                RTFHelpener rtfHelper = new RTFHelpener(findText(paragraphs));
                foreach (DBTemplatesHelper.DBParagraph p in paragraphs)
                {
                    SoftwareSctipt scrip;
                    if (p.flag == 0)
                    {
                        scrip = new SoftwareSctipt(p.text, SoftwareSctipt.SCRIPT_TYPE.STRING);
                        rtfHelper.replaceScriptToText(p.id, scrip.runString("no script"));
                    }
                }


                Word.Application app = new Word.Application();
                app.Visible = false;
                Word.Document doc;
                Object template = null;
                Object newTemplate = false;
                Object documentType = 0;
                Object visible = false;


                doc = app.Documents.Add(template, newTemplate, documentType, visible);
                doc.Activate();
                Clipboard.SetText(rtfHelper.Rtf, TextDataFormat.Rtf);
                app.Selection.Paste();

                doc.SaveAs2(filename, 16, false, Type.Missing, false,
                 Type.Missing, false, false, false, false, false, 0,
                 false, false, true);
                app.Quit(0, 0, false);

            }

            private static String findText(List<DBTemplatesHelper.DBParagraph> paragraphs)
            {
                foreach (DBTemplatesHelper.DBParagraph p in paragraphs)
                {
                    if (p.flag == 1)
                    {
                        return p.text;
                    }
                }
                return "";
            }

        }
    }
