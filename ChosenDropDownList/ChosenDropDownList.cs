using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChosenDropDownList
{
    [ToolboxData("<{0}:EmbeddedChosenDdl runat=server></{0}:EmbeddedChosenDdl>")]
    //[ViewStateModeById]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    [PersistChildren(true)]
    public class ChosenDropDownList : System.Web.UI.UserControl//, IPostBackDataHandler
    {
        #region Events
        // todo: trigger event SelectedIndexChanged
        private event EventHandler<EventArgs> SelectedIndexChanged;
        #endregion

        #region Fields
        private HiddenField hdnChosen = new HiddenField();
        private HiddenField hdnAddedChosen = new HiddenField();
        private ChosenDropDownListBase ddlChosen = new ChosenDropDownListBase();
        private string hdnChosenID
        {
            get
            {
                object o = ViewState["hdnChosenID"];
                if (o != null)
                    return o.ToString();
                else
                {
                    string id = "ddlChosen" + Guid.NewGuid().ToString().Replace("-", "");
                    ViewState["hdnChosenID"] = id;
                    return id;
                }
            }
            set
            {
                ViewState["hdnChosenID"] = value;
            }
        }
        private string hdnAddedChosenID
        {
            get
            {
                object o = ViewState["hdnAddedChosenID"];
                if (o != null)
                    return o.ToString();
                else
                {
                    string id = "hdnAddedChosen" + Guid.NewGuid().ToString().Replace("-", "");
                    ViewState["hdnAddedChosenID"] = id;
                    return id;
                }
            }
            set
            {
                ViewState["hdnAddedChosenID"] = value;
            }
        }
        private string ddlChosenID
        {
            get
            {
                object o = ViewState["ddlChosenID"];
                if (o != null)
                    return o.ToString();
                else
                {
                    string id = "ddlChosen" + Guid.NewGuid().ToString().Replace("-", "");
                    ViewState["ddlChosenID"] = id;
                    return id;
                }
            }
            set
            {
                ViewState["ddlChosenID"] = value;
            }
        }

        private string hdnChosenSavedValue
        {
            get
            {
                object o = ViewState["hdnChosen"];
                if (o != null)
                    return o.ToString();
                else
                    return null;
            }

            set
            {
                ViewState["NoResultsText"] = value;
            }
        }

        private object ddlChosenSavedDataSource
        {
            get
            {
                object o = ViewState["ddlChosen"];
                if (o != null )
                    return o;
                else
                    return null;
            }

            set
            {
                ViewState["ddlChosen"] = value;
            }
        }

        private string hdnAddedChosenSavedValue
        {
            get
            {
                object o = ViewState["hdnAddedChosen"];
                if (o != null)
                    return o.ToString();
                else
                    return null;
            }

            set
            {
                ViewState["hdnAddedChosen"] = value;
            }
        }
        #endregion

        #region Properties
        public bool IsMultiselect
        {
            get { return ddlChosen.IsMultiselect; }
            set { ddlChosen.IsMultiselect = value; }
        }

        public string NoResultsText
        {
            get
            {
                return ddlChosen.NoResultsText;
            }

            set
            {
                ddlChosen.NoResultsText = value;
            }
        }

        public string PlaceholderTextMultiple
        {
            get
            {
                return ddlChosen.PlaceholderTextMultiple;
            }

            set
            {
                ddlChosen.PlaceholderTextMultiple = value;
            }
        }

        public string PlaceholderTextSingle
        {
            get
            {
                return ddlChosen.PlaceholderTextSingle;
            }

            set
            {
                ddlChosen.PlaceholderTextSingle = value;
            }
        }

        public string CreateOptionText
        {
            get
            {
                return ddlChosen.CreateOptionText;
            }

            set
            {
                ddlChosen.CreateOptionText = value;
            }
        }

        public bool AllowSingleDeselect
        {
            get
            {
                return ddlChosen.AllowSingleDeselect;
            }

            set
            {
                ddlChosen.AllowSingleDeselect = value;
            }
        }

        public bool SearchContains
        {
            get
            {
                return ddlChosen.SearchContains;
            }

            set
            {
                ddlChosen.SearchContains = value;
            }
        }

        public bool DisableSearch
        {
            get
            {
                return ddlChosen.DisableSearch;
            }

            set
            {
                ddlChosen.DisableSearch = value;
            }
        }

        public int MaxSelectedOptions
        {
            get
            {
                return ddlChosen.MaxSelectedOptions;
            }

            set
            {
                ddlChosen.MaxSelectedOptions = value;
            }
        }

        public string Width
        {
            get
            {
                return ddlChosen.Width;
            }

            set
            {
                ddlChosen.Width = value;
            }
        }

        public List<string> SelectedValues
        {
            get
            {
                return ddlChosen.SelectedValues;
            }

            set
            {
                ddlChosen.SelectedValues = value;
            }
        }

        public bool CreateOption
        {
            get
            {
                return ddlChosen.CreateOption;
            }
            set { ddlChosen.CreateOption = value; }
        }

        public List<string> AddedOptionValues
        {
            get
            {
                return ddlChosen.AddedOptionValues;
            }

            set
            {
                ddlChosen.AddedOptionValues = value;
            }
        }

        public string DefaultSelectedValues
        {
            get
            {
                return ddlChosen.DefaultSelectedValues;
            }

            set
            {
                ddlChosen.DefaultSelectedValues = value;
            }
        }

        public object DataSource
        {
            get { return ddlChosen.DataSource; }
            set { ddlChosen.DataSource = value; }
        }

        public string DataTextField
        {
            get { return ddlChosen.DataTextField; }
            set { ddlChosen.DataTextField = value; }
        }
        public string DataValueField
        {
            get { return ddlChosen.DataValueField; }
            set { ddlChosen.DataValueField = value; }
        }
        public string DataTextFormatString
        {
            get { return ddlChosen.DataTextFormatString; }
            set { ddlChosen.DataTextFormatString = value; }
        }
        public string CssClass
        {
            get { return ddlChosen.CssClass; }
            set { ddlChosen.CssClass = value; }
        }
        #endregion

        public override void DataBind()
        {
            ddlChosen.DataBind();
            base.DataBind();
        }

        //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "Execution")]
        protected override void CreateChildControls()
        {
            if (hdnChosenSavedValue != null)
                hdnChosen.Value = hdnChosenSavedValue;
            this.Controls.Add(hdnChosen);

            if (hdnAddedChosenSavedValue != null)
                hdnAddedChosen.Value = hdnAddedChosenSavedValue;
            this.Controls.Add(hdnAddedChosen);

            if (ddlChosenSavedDataSource != null)
                ddlChosen.DataSource = ddlChosenSavedDataSource;
            ////ddlChosen.SelectedIndexChanged += new EventHandler(ddlChosen_SelectedIndexChanged);
            this.Controls.Add(ddlChosen);
            ddlChosen.DataBind();
        }

        void ddlChosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(this, e);
            }
        }


        protected override void RenderChildren(HtmlTextWriter output)
        {
            base.RenderChildren(output);
        }

        protected override void OnPreRender(EventArgs e)
        {
            EnableViewState = true;
            //Page.RegisterRequiresPostBack(this);
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            ddlChosen.ID = ddlChosenID;
            hdnAddedChosen.ID = hdnAddedChosenID;
            hdnChosen.ID = hdnChosenID;
            ddlChosen.HiddenFieldID = hdnChosen.ID;
            ddlChosen.AddedItemsHdnID = hdnAddedChosen.ID;
            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            ddlChosenID = ddlChosen.ID;
            hdnAddedChosenID = hdnAddedChosen.ID;
            hdnChosenID = hdnChosen.ID;
            hdnChosen.ID = ddlChosen.HiddenFieldID;
            hdnAddedChosen.ID = ddlChosen.AddedItemsHdnID;
            ddlChosenSavedDataSource = ddlChosen.Items;
            base.OnUnload(e);
        }
    }
}
