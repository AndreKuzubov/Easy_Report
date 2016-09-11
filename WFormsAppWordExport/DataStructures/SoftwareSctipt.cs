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
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using WFormsAppWordExport.DataStructures;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace WFormsAppWordExport.DataStructures
{
    public class SoftwareSctipt
    {
        private Essence currEssence;
        private Feature currFeature;
        

        public enum SCRIPT_TYPE { FUNC_BOOL,VOID,STRING }
        public String script { get; private set; }

        private Func<ProjectDataHelper,Essence,Feature,bool, bool> boolFunc= delegate (ProjectDataHelper es,Essence currEssence, Feature currFeature,bool def) {return def; };
        private Action<ProjectDataHelper, Essence, Feature> voidFunc = delegate (ProjectDataHelper es, Essence currEssence, Feature currFeature) { };
        private Func<ProjectDataHelper, Essence, Feature, String> stringFunc = delegate (ProjectDataHelper es, Essence currEssence, Feature currFeature) { return ""; };

        public SoftwareSctipt (String script,SCRIPT_TYPE type)
        { 
            this.script = script;
            bild(type);
        }

        public SoftwareSctipt(String script, SCRIPT_TYPE type,Essence currEssence):this(script,type)
        {
            this.currEssence = currEssence;
        }

        public SoftwareSctipt(String script, SCRIPT_TYPE type, Essence currEssence,Feature currFeature): this(script, type,currEssence)
        {
            this.currFeature = currFeature;
        }

        public static CompilerResults compile(String script,SCRIPT_TYPE type)
        {
            if (script == null || script.Length == 0)
            {
                return null;
            }

            String methodType=null;
            string specParams = "";
            switch (type)
            {
                case SCRIPT_TYPE.FUNC_BOOL:
                    methodType = @"bool";
                    specParams = @", bool def";
                    break;
                case SCRIPT_TYPE.VOID:
                    methodType = @"void";
                    break;
                case SCRIPT_TYPE.STRING:
                    methodType = @"string";
                    break;
            }
          
            string code = @"
        using System;
        using System.Collections.Generic;
       // using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Runtime.Serialization;
       // using System.Xml.Serialization;
        using System.IO;
        using System.Windows.Forms;
        using  WFormsAppWordExport.DataStructures;
            
        namespace WFormsAppWordExport
        {                
            public static class BinaryFunction
            {                
                public static " + methodType + @" Function(ProjectDataHelper DataProject, Essence currEssence, Feature currFeature"+ specParams + @" )
                {
                    func_xy
                }
            }
        }
    ";

            string finalCode = code.Replace("func_xy", script);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters p = new CompilerParameters()
            {
                GenerateInMemory = true
            };
            String path = Assembly.GetExecutingAssembly().Location;
            p.ReferencedAssemblies.Add(path);
            var assemblies = typeof(ProjectDataHelper).Assembly.GetReferencedAssemblies().ToList();
            var assemblyLocations = assemblies.Select(a => Assembly.ReflectionOnlyLoad(a.FullName).Location).ToList();
            assemblyLocations.Add(typeof(ProjectDataHelper).Assembly.Location);
            p.ReferencedAssemblies.AddRange(assemblyLocations.ToArray());

            return provider.CompileAssemblyFromSource(p, new string[] { finalCode });
        }

        private void bild(SCRIPT_TYPE type)
        {
            CompilerResults results = compile(script, type);
            if (results == null) return;
            Type binaryFunction = results.CompiledAssembly.GetType("WFormsAppWordExport.BinaryFunction");
            MethodInfo method = binaryFunction.GetMethod("Function");

            switch (type)
            {
                case SCRIPT_TYPE.FUNC_BOOL:
                    boolFunc = (Func<ProjectDataHelper,Essence,Feature,bool, bool>)Delegate.CreateDelegate(typeof(Func<ProjectDataHelper,Essence,Feature,bool, bool>), method);
                    break;
                case SCRIPT_TYPE.VOID:
                    voidFunc = (Action<ProjectDataHelper, Essence, Feature>)Delegate.CreateDelegate(typeof(Action<ProjectDataHelper, Essence, Feature>), method);
                    break;
                case SCRIPT_TYPE.STRING:
                    //methodType = @"string";
                    stringFunc = (Func<ProjectDataHelper, Essence, Feature, String>)Delegate.CreateDelegate(typeof(Func<ProjectDataHelper, Essence, Feature, String>), method);
                    break;
            }

                
        }
        
        public void run()
        {
            if (ProjectDataHelper.Initial!=null)
                 voidFunc(ProjectDataHelper.Initial,currEssence,currFeature);
        }

        public bool runBool(bool def)
        {
            if (ProjectDataHelper.Initial != null)
                return boolFunc(ProjectDataHelper.Initial,currEssence,currFeature,def);
            return def;
        }

        public String runString(String def)
        {
            if (ProjectDataHelper.Initial != null)
                return stringFunc(ProjectDataHelper.Initial, currEssence, currFeature);
            return def;
        }
    }

}
