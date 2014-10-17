using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: System.Web.UI.WebResource("ChosenDropDownList.chosen-sprite.png", "img/png")]
[assembly: System.Web.UI.WebResource("ChosenDropDownList.chosen-sprite@2x.png", "img/png")]
[assembly: WebResource("ChosenDropDownList.chosen.css", "text/css")]
namespace ChosenDropDownList
{
    [ToolboxData("<{0}:ChosenDropDownList runat=server></{0}:ChosenDropDownList>")]
    //[ViewStateModeById]
    public class ChosenDropDownListBase : DropDownList
    {
        #region Properties
        private bool _isMultiselect
        {
            get
            {
                object vs = ViewState["IsMultiselect"];
                bool retVal = true;
                if (vs != null)
                    Boolean.TryParse(vs.ToString(), out retVal);
                return retVal;
            }

            set
            {
                ViewState["IsMultiselect"] = value;
            }
        }
        public bool IsMultiselect
        {
            get { return _isMultiselect; }
            set { _isMultiselect = value; }
        }

        public string NoResultsText
        {
            get
            {
                String s = (String)ViewState["NoResultsText"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["NoResultsText"] = value;
            }
        }

        public string PlaceholderTextMultiple
        {
            get
            {
                String s = (String)ViewState["PlaceholderTextMultiple"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["PlaceholderTextMultiple"] = value;
            }
        }

        public string PlaceholderTextSingle
        {
            get
            {
                String s = (String)ViewState["PlaceholderTextSingle"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["PlaceholderTextSingle"] = value;
            }
        }

        public string CreateOptionText
        {
            get
            {
                String s = (String)ViewState["CreateOptionText"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["CreateOptionText"] = value;
            }
        }

        public bool SearchContains
        {
            get
            {
                object s = ViewState["SearchContains"];
                return ((s == null) ? true : Convert.ToBoolean(s));
            }

            set
            {
                ViewState["SearchContains"] = value;
            }
        }

        public bool DisableSearch
        {
            get
            {
                object s = ViewState["DisableSearch"];
                return ((s == null) ? false : Convert.ToBoolean(s));
            }

            set
            {
                ViewState["DisableSearch"] = value;
            }
        }

        public int MaxSelectedOptions
        {
            get
            {
                object s = ViewState["MaxSelectedOptions"];
                return ((s == null) ? 0 : Convert.ToInt32(s));
            }

            set
            {
                ViewState["MaxSelectedOptions"] = value;
            }
        }

        public bool AllowSingleDeselect
        {
            get
            {
                object s = ViewState["AllowSingleDeselect"];
                return ((s == null) ? false : Convert.ToBoolean(s));
            }

            set
            {
                ViewState["AllowSingleDeselect"] = value;
            }
        }

        public string Width
        {
            get
            {
                String s = (String)ViewState["Width"];
                return ((s == null) ? "auto" : s);
            }

            set
            {
                ViewState["Width"] = value;
            }
        }

        public List<string> SelectedValues
        {
            get
            {
                if (!string.IsNullOrEmpty(_selectedValuesJoined))
                    return _selectedValuesJoined.Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList();
                else
                    return new List<string>();
            }
            set { _selectedValuesJoined = string.Join(",", value.ToArray()); }
        }

        public string HiddenFieldID
        {
            get
            {
                String s = (String)ViewState["HiddenFieldID"];
                if (s != null)
                    return s.ToString();
                else
                    throw new ArgumentNullException("HiddenFieldID must be defined!");
            }

            set
            {
                ViewState["HiddenFieldID"] = value;
            }
        }

        private string _selectedValuesJoined
        {
            get 
            {
                //if (Page.FindControl(HiddenFieldID) != null)
                //    return (Page.FindControl(HiddenFieldID) as HiddenField).Value;
                if(Page != null && GetControlByNameFromParent<HiddenField>(Page,HiddenFieldID) != null)
                    return (GetControlByNameFromParent<HiddenField>(Page, HiddenFieldID) as HiddenField).Value;
                else
                    return string.Empty;
            }
            set
            {
                if (Page.FindControl(HiddenFieldID) != null)
                    (Page.FindControl(HiddenFieldID) as HiddenField).Value = value;
            }
        }
        protected string SelectedValuesJoined
        {
            get { return _selectedValuesJoined; }
            set { _selectedValuesJoined = value; }
        }

        public string DefaultSelectedValues
        {
            get
            {
                String s = (String)ViewState["DefaultSelectedValues"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["DefaultSelectedValues"] = value;
            }
        }

        public bool CreateOption
        {
            get
            {
                object s = ViewState["create_option"];
                return ((s == null) ? false : Convert.ToBoolean(s));
            }

            set
            {
                ViewState["create_option"] = value;
            }
        }

        public string AddedItemsHdnID
        {
            get
            {
                String s = (String)ViewState["AddedItemsHdnID"];
                if (s != null)
                    return s.ToString();
                else if (CreateOption)
                {
                    throw new ArgumentNullException("AddedItemsHdnID must be defined!");
                }
                return string.Empty;
            }

            set
            {
                ViewState["AddedItemsHdnID"] = value;
            }
        }

        public List<string> AddedOptionValues
        {
            get
            {
                if (!string.IsNullOrEmpty(_addedValuesJoined))
                    return _addedValuesJoined.Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList();
                else
                    return new List<string>();
            }
            set { _addedValuesJoined = string.Join(",", value.ToArray()); }
        }

        private string _addedValuesJoined
        {
            get
            {
                if (Page != null && GetControlByNameFromParent<HiddenField>(Page, AddedItemsHdnID) != null)
                    return (GetControlByNameFromParent<HiddenField>(Page, AddedItemsHdnID) as HiddenField).Value;
                else
                    return string.Empty;
            }
            set
            {
                if (Page.FindControl(AddedItemsHdnID) != null)
                    (Page.FindControl(AddedItemsHdnID) as HiddenField).Value = value;
            }
        }

        //public override object DataSource
        //{
        //    get
        //    {
        //        return ViewState["DataSource"];
        //    }

        //    set
        //    {
        //        ViewState["DataSource"] = value;
        //    }
        //}
        #endregion

        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("jQuery"))
                Page.ClientScript.RegisterClientScriptInclude("jQuery",
                    Page.ClientScript.GetWebResourceUrl(this.GetType(), "ChosenDropDownList.jquery-1.10.2.min.js"));
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("ChosenControlJS"))
                Page.ClientScript.RegisterClientScriptInclude("ChosenControlJS",
                     Page.ClientScript.GetWebResourceUrl(this.GetType(), "ChosenDropDownList.chosen.jquery.min.js"));
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("ChosenControlCreateOptionJS"))
                Page.ClientScript.RegisterClientScriptInclude("ChosenControlCreateOptionJS",
                     Page.ClientScript.GetWebResourceUrl(this.GetType(), "ChosenDropDownList.chosen-create-option.jquery.js"));

            SetupDropDown();

            if (SelectedValues.Count > 0 || !string.IsNullOrEmpty(DefaultSelectedValues))
            {
                StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("setTimeout(function(){ ");
                if (SelectedValues.Count > 0)
                {
                    foreach (string item in SelectedValues)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            sbSelect.AppendFormat("$('#{0}_chosen').trigger(\"mousedown\"); ", ClientID);
                            int index = Items.IndexOf(Items.FindByValue(item));
                            sbSelect.AppendFormat("$('[data-option-array-index=\"{0}\"]').trigger(\"mouseup\"); ", index);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(DefaultSelectedValues))
                {
                    foreach (string item in DefaultSelectedValues.Split(','))
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            sbSelect.AppendFormat("$('#{0}_chosen').trigger(\"mousedown\"); ", ClientID);
                            int index = Items.IndexOf(Items.FindByValue(item));
                            sbSelect.AppendFormat("$('[data-option-array-index=\"{0}\"]').trigger(\"mouseup\"); ", index);
                        }
                    }
                }
                sbSelect.Append("}, 100);");
                Page.ClientScript.RegisterStartupScript(typeof(ChosenDropDownListBase), "selectDdl" + ID, sbSelect.ToString(), true);
            }

            Page.RegisterRequiresPostBack(this);
            
            base.OnPreRender(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            string css = "<link href=\"" + Page.ClientScript.GetWebResourceUrl(this.GetType(),
            "ChosenDropDownList.chosen.css") + "\" type=\"text/css\" rel=\"stylesheet\" />";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "cssFile", css, false);

        }

        public void SetupDropDown()
        {
            if (DisableSearch && !IsMultiselect)
                return;

            StringBuilder sbJs = new StringBuilder();
            //sbJs.Append("setTimeout(function(){ ");
            sbJs.AppendFormat("$(document).ready(function () {{ Sys.WebForms.PageRequestManager.getInstance().add_endRequest(afterAsyncLoad{0}); afterAsyncLoad{0}(null, null);}}); function afterAsyncLoad{0}(sender, args) {{", ClientID);

            sbJs.AppendFormat("$(\"select[id$='{0}'\").chosen({{ ", ClientID);
            List<string> chosenParams = new List<string>();
            chosenParams.Add("inherit_select_classes: true");
            if (!string.IsNullOrEmpty(NoResultsText))
                chosenParams.Add(string.Format("no_results_text: \"{0}\"", NoResultsText));
            if (!string.IsNullOrEmpty(Width))
                chosenParams.Add(string.Format("width: \"{0}\"", Width));
            if (!string.IsNullOrEmpty(PlaceholderTextSingle))
                chosenParams.Add(string.Format("placeholder_text_single: \"{0}\"", PlaceholderTextSingle));
            if (!string.IsNullOrEmpty(PlaceholderTextMultiple))
                chosenParams.Add(string.Format("placeholder_text_multiple: \"{0}\"", PlaceholderTextMultiple));
            if (DisableSearch)
                chosenParams.Add("disable_search: true");
            if (SearchContains)
                chosenParams.Add("search_contains: true");
            if(!IsMultiselect)
                chosenParams.Add("allow_single_deselect: true");
            if (MaxSelectedOptions > 0)
                chosenParams.Add(string.Format("max_selected_options: {0}", MaxSelectedOptions.ToString()));
            if (CreateOption)
            {
                chosenParams.Add("create_option: true");
                chosenParams.Add("skip_no_results: true");
                if (!string.IsNullOrEmpty(CreateOptionText))
                    chosenParams.Add("create_option_text: " + CreateOptionText);
            }

            if (chosenParams.Count > 0)
                sbJs.Append(string.Join(", ", chosenParams));
            sbJs.Append("})");

            if (IsMultiselect)
            {
                if (!CreateOption)
                    sbJs.AppendFormat(".change(function() {{$(\"input[id$='{0}']\")[0].value = $(this).val();}}) ", HiddenFieldID);
                else
                    sbJs.AppendFormat(".change(function () {{ var exists = false; for (i = 0; i < $(\"select[id$='{0}']\")[0].length; ++i) {{ if ($(\"select[id$='{0}']\")[0].options[i].value == $(this).val()[$(this).val().length - 1] && $(\"select[id$='{0}']\")[0].options[i].attributes('new_option') == undefined) {{ exists = true; }} }} if (!exists) {{$(\"input[id$='{1}'\")[0].value = $(this).val()[$(this).val().length - 1];}} $(\"input[id$='{2}'\")[0].value = $(this).val(); }});", this.ClientID, AddedItemsHdnID, HiddenFieldID);
                Attributes.Add("multiple", "");
            }
            if (CreateOption && !IsMultiselect)
                sbJs.AppendFormat(".change(function () {{ var exists = false; for (i = 0; i < $(\"select[id$='{0}']\")[0].length; ++i) {{ if ($(\"select[id$='{0}']\")[0].options[i].value == $(this).val() && $(\"select[id$='{0}']\")[0].options[i].attributes('new_option') == undefined) {{ exists = true; }}}} if(!exists) {{ $(\"input[id$='{1}'\")[0].value = $(this).val();}}  $(\"input[id$='{1}'\")[0].value = $(this).val(); }});", this.ClientID, AddedItemsHdnID, HiddenFieldID);

            //sbJs.Append("}, 100)");
            sbJs.Append(";");
            sbJs.Append("}");
            Page.ClientScript.RegisterStartupScript(typeof(ChosenDropDownListBase), "ddl" + ID, sbJs.ToString(), true);
        }

        /// <summary>
        /// Find parent control of type
        /// </summary>
        /// <typeparam name="T">type of parent control</typeparam>
        /// <param name="childControl">child control</param>
        /// <returns>First parent control of specified type</returns>
        private static T FindParentOfType<T>(Control childControl)
        {
            var curParent = childControl.Parent;
            while (curParent != null && !(curParent is T))
            {
                curParent = curParent.Parent;
            }
            return (T)(object)curParent;
        }

        /// <summary>
        /// Get control by name from parent control
        /// </summary>
        /// <typeparam name="T">Type of control to search for</typeparam>
        /// <param name="parentControl">Control to search in</param>
        /// <param name="controlId">Control to search for ID</param>
        /// <param name="exactId">Is given controlId exact or just partial name (default true)</param>
        /// <returns>found control or first found control if multiple results found or null if not found</returns>
        private static Control GetControlByNameFromParent<T>(Control parentControl, string controlId, bool exactId = true)
        {
            List<Control> candidateControls = new List<Control>();
            GetControlListOfTypeFromParent<T>(parentControl, ref candidateControls);
            if (exactId)
                candidateControls = candidateControls.Where(c => c.ID == controlId).ToList();
            else
                candidateControls = candidateControls.Where(c => c.ID.Contains(controlId)).ToList();

            if (candidateControls.Count > 0)
                return candidateControls.First();
            else
                return null;
        }

        /// <summary>
        /// Get all controls of type T from parent control
        /// </summary>
        /// <param name="parentControl">Control to serach in</param>
        /// <param name="controlsList">List of found controls</param>
        private static void GetControlListOfTypeFromParent<T>(Control parentControl, ref List<Control> controlsList)
        {
            Type tip = typeof(T);
            foreach (var ctrl in parentControl.Controls)
            {
                if (ctrl.GetType() == typeof(T) || ctrl is T)
                    controlsList.Add(ctrl as Control);
                else if ((ctrl as Control).HasControls())
                    GetControlListOfTypeFromParent<T>(ctrl as Control, ref controlsList);
            }
        }
    }
}
