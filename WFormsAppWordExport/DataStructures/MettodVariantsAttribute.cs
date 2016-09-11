using System;

namespace WFormsAppWordExport.DataStructures
{
    [System.AttributeUsage(System.AttributeTargets.Parameter, Inherited = true)]

    class MettodVariantsAttribute : System.Attribute
    {
        //Func<AutocompleteMenuNS.AutocompleteItem[]> d;
        String funcName;
        Type declarationParent;
        
        public MettodVariantsAttribute(Type declarationParent, String funcName)
        {
            this.declarationParent = declarationParent;
            this.funcName = funcName;
        }

        public AutocompleteMenuNS.AutocompleteItem[] getAutomCompleteItems()
        {
            return (AutocompleteMenuNS.AutocompleteItem[])
                declarationParent.GetMethod(funcName).Invoke(null,null);
        }

    }
}
