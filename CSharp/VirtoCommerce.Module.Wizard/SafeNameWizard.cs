using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Module.Wizard
{
    public class SafeNameWizard : IWizard
    {
        #region MyRegion
        #pragma warning disable S1186 // Methods should not be empty
        public void BeforeOpeningFile(ProjectItem projectItem) { }

        public void ProjectFinishedGenerating(Project project) { }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }

        public void RunFinished() { }
        #pragma warning restore S1186 // Methods should not be empty 
        #endregion

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var safeprojectname = replacementsDictionary["$safeprojectname$"];
            var supersafename = Safe(safeprojectname);
            var supersafenamejs = ToCamelCase(supersafename);

            replacementsDictionary.Add("$supersafename$", supersafename);
            replacementsDictionary.Add("$supersafenamejs$", supersafenamejs);
        }

        private string Safe(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in value)
            {
                if (!char.IsLetterOrDigit(item))
                    continue;

                stringBuilder.Append(item);
            }

            if (stringBuilder.Length == 0)
                return "Proj";

            if (char.IsDigit(stringBuilder[0]))
                stringBuilder.Insert(0, "_");

            return stringBuilder.ToString();
        }

        private string ToCamelCase(string value)
        {
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }
}
