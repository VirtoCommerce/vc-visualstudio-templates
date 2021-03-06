using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace VirtoCommerce.Module.Wizard
{
    public class SafeNameWizard : IWizard
    {
        #region NotImplemented
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

            const string extenssionToRemove = "module";
            if (safeprojectname.EndsWith(extenssionToRemove, System.StringComparison.InvariantCultureIgnoreCase))
            {
                safeprojectname = safeprojectname.Remove(safeprojectname.Length - extenssionToRemove.Length);
            }

            var supersafename = Safe(safeprojectname);
            var supersafenamejs = ToJsCamelCase(supersafename);
            var safeprojectnamejs = SafeJs(safeprojectname);

            var projectnameitems = safeprojectname.Split('.').Select(x => ToJsCamelCase(Safe(x)));
            var safeprojectnamecamel = string.Join(".", projectnameitems);

            replacementsDictionary.Add("$shortsafename$", safeprojectname); // XXmodule = XX
            replacementsDictionary.Add("$supersafename$", supersafename); // 0ProjectName XX = _ProjectNameXX
            replacementsDictionary.Add("$supersafenamejs$", supersafenamejs); // ProjectNameXX = projectNameXX
            replacementsDictionary.Add("$safeprojectnamejs$", safeprojectnamejs); // ProjectNameXX = project-name-xx
            replacementsDictionary.Add("$safeprojectnamecamel$", safeprojectnamecamel); // ProjectName.Web = projectName.web
        }

        private string SafeJs(string value)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                var item = value[i];

                if (char.IsUpper(item) && i > 0)
                {
                    var prev = value[i - 1];
                    if (!char.IsUpper(prev) && !char.IsPunctuation(prev))
                        stringBuilder.Append('-');
                }

                stringBuilder.Append(item);
            }

            return stringBuilder.ToString().ToLower();
        }

        private string Safe(string value)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in value)
            {
                if (char.IsLetterOrDigit(item))
                    stringBuilder.Append(item);
            }

            if (stringBuilder.Length == 0)
                return "Proj";

            if (char.IsDigit(stringBuilder[0]))
                stringBuilder.Insert(0, "_");

            return stringBuilder.ToString();
        }

        private string ToJsCamelCase(string value)
        {
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }
}
