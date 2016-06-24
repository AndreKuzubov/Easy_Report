using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public enum SCRIPT_TYPE { FUNC_BOOL,VOID,STRING }
        public String script { get; private set; }

        private Func<TreeNodeCollection, bool> boolFunc= delegate (TreeNodeCollection es){return true;};
        private Action<TreeNodeCollection> voidFunc = delegate (TreeNodeCollection es) { };

        public SoftwareSctipt (String script,SCRIPT_TYPE type)
        {
          
            this.script = script;
            bild(type);
        }

        public static CompilerResults compile(String script,SCRIPT_TYPE type)
        {
            if (script == null || script.Length == 0)
            {
                return null;
            }

            String methodType=null;
            switch (type)
            {
                case SCRIPT_TYPE.FUNC_BOOL:methodType = @"bool";
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
            public class BinaryFunction
            {                
                public static " + methodType + @" Function(TreeNodeCollection rootData)
                {
                    func_xy
                }
            }
        }
    ";
            var delegateType = Expression.GetFuncType(typeof(Essence), typeof(bool));

            string finalCode = code.Replace("func_xy", script);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters p = new CompilerParameters()
            {
                GenerateInMemory = true
            };
            String path = Assembly.GetExecutingAssembly().Location;
            p.ReferencedAssemblies.Add(path);
            var assemblies = typeof(TreeNodeCollection).Assembly.GetReferencedAssemblies().ToList();
            var assemblyLocations = assemblies.Select(a => Assembly.ReflectionOnlyLoad(a.FullName).Location).ToList();
            assemblyLocations.Add(typeof(TreeNodeCollection).Assembly.Location);
            p.ReferencedAssemblies.AddRange(assemblyLocations.ToArray());

            return provider.CompileAssemblyFromSource(p, new string[] { finalCode });
        }

        private void bild(SCRIPT_TYPE type)
        {
         /*   if (script == null || script.Length == 0)
            {
                boolFunc = delegate (TreeNodeCollection es) { return true; };
                return;
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
            public class BinaryFunction
            {                
                public static "+((type==SCRIPT_TYPE.FUNC_BOOL)?"bool":"void")+@" Function(TreeNodeCollection rootData)
                {
                    func_xy
                }
            }
        }
    ";
            var delegateType = Expression.GetFuncType(typeof(Essence), typeof(bool));

            string finalCode = code.Replace("func_xy", script);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;
            String path = Assembly.GetExecutingAssembly().Location;
            p.ReferencedAssemblies.Add(path);
            var assemblies = typeof(TreeNodeCollection).Assembly.GetReferencedAssemblies().ToList();
            var assemblyLocations = assemblies.Select(a =>Assembly.ReflectionOnlyLoad(a.FullName).Location).ToList();
            assemblyLocations.Add(typeof(TreeNodeCollection).Assembly.Location);
            p.ReferencedAssemblies.AddRange(assemblyLocations.ToArray());
            */

            CompilerResults results = compile(script, type);//  provider.CompileAssemblyFromSource(p, new string[] { finalCode });
            if (results == null) return;
            Type binaryFunction = results.CompiledAssembly.GetType("WFormsAppWordExport.BinaryFunction");
            MethodInfo method = binaryFunction.GetMethod("Function");
            if (type==SCRIPT_TYPE.FUNC_BOOL)
                boolFunc=(Func<TreeNodeCollection, bool>) Delegate.CreateDelegate(typeof(Func<TreeNodeCollection, bool>),method);
            else
                voidFunc = (Action<TreeNodeCollection>)Delegate.CreateDelegate(typeof(Action<TreeNodeCollection>), method);
        }

        public void run()
        {
            voidFunc(Form1.rootData);
        }

        public bool runBool()
        {
             return boolFunc(Form1.rootData);
        }
    }

}
