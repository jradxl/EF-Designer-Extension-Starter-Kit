using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;

namespace StarterKitExtension.Wizard
{
    public class StarterKitExtensionWizard : IWizard
    {
        /// <summary>
        /// Runs custom wizard logic before opening an item in the template.
        /// </summary>
        /// <param name="projectItem">The project item that will be opened.</param>
        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project has finished generating.
        /// </summary>
        /// <param name="project">The project that finished generating.</param>
        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project item has finished generating.
        /// </summary>
        /// <param name="projectItem">The project item that finished generating.</param>
        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public void RunFinished()
        {
        }

        /// <summary>
        /// Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A <see cref="T:Microsoft.VisualStudio.TemplateWizard.WizardRunKind" /> indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        /// <exception cref="Microsoft.VisualStudio.TemplateWizard.WizardCancelledException">Action cancelled by user</exception>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {

            DTE dte = automationObject as DTE;

            //Get a reference to the Item currently selected in the Solution Explorer
            SelectedItem item = dte.SelectedItems.Item(1);

            //Check if the $edmxInputFile$ token is already in the replacementDictionnary.
            //If it is, it means the file was added through the "Add Code Generation Item..." menu,
            //and we don't need to set it here. The token was actually set by the 
            //Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.AddArtifactGeneratorWizard WizardExtension
            //(see the file StarterKitExtension.ItemTemplate.vstemplate in the StarterKitExtension.ItemTemplate project)
            if (!replacementsDictionary.ContainsKey("$edmxInputFile$"))
            {
                ModelChoser frm = new ModelChoser(dte, item);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Substitute the EDMX filename within the template
                    replacementsDictionary.Add("$edmxInputFile$", frm.ModelFile);
                }
                else
                {
                    throw new WizardCancelledException("Action cancelled by user");
                }

            }
        }

        /// <summary>
        /// Indicates whether the specified project item should be added to the project.
        /// </summary>
        /// <param name="filePath">The path to the project item.</param>
        /// <returns>
        /// true if the project item should be added to the project; otherwise, false.
        /// </returns>
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
