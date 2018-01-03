using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer.ProductListingBL;
using BusinessLayer;
using PresentationLayer.MasterPages;

namespace PresentationLayer
{
    public partial class ProductListing : System.Web.UI.Page
    {
        ProductListingBLClass objProductListingBLClass = new ProductListingBLClass();
        BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
        DataSet dt1, dt2, dt3;
        MainMaster objMainMaster = new MainMaster();

        List<string> productFilter = new List<string>();
        Dictionary<string, string> dictListProd = new Dictionary<string, string>();

        public List<string> lstStdUser
        {
            get
            {
                if (Session["listproductFilter"] == null)
                    return new List<string>();
                else
                    return Session["listproductFilter"] as List<string>;
            }
            set
            {
                Session["listproductFilter"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lstStdUser = new List<string>();
                BindData();

                DataSet dsrowHead = new DataSet();
                dsrowHead = objProductListingBLClass.filterByCategory();
                tvFiltering.Nodes.Clear();

                foreach (DataRow rowHead in dsrowHead.Tables[0].Rows)
                {
                    TreeNode parent = new TreeNode();
                    parent.Text = rowHead["TCY_CATEGORY_NAME"].ToString();
                    parent.Value = rowHead["TCY_CATEGORY_ID"].ToString();
                    tvFiltering.Nodes.Add(parent);

                    DataSet dsChild = new DataSet();
                    dsChild = objProductListingBLClass.Filtering(rowHead["TCY_CATEGORY_ID"].ToString());
                    foreach (DataRow rowChild in dsChild.Tables[0].Rows)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = rowChild["TCY_CATEGORY_NAME"].ToString();
                        child.Value = rowChild["TCY_CATEGORY_ID"].ToString();
                        parent.ChildNodes.Add(child);

                        DataSet dsLeaf = new DataSet();
                        dsLeaf = objProductListingBLClass.ChildFilter(rowChild["TCY_CATEGORY_NAME"].ToString());
                        foreach (DataRow rowLeaf in dsLeaf.Tables[0].Rows)
                        {
                            TreeNode leaf = new TreeNode();
                            leaf.Text = rowLeaf["TP_PRODUCT_NAME"].ToString();
                            leaf.Value = rowLeaf["TP_PRODUCT_ID"].ToString();
                            child.ChildNodes.Add(leaf);
                        }
                    }

                }
                Session["listproductFilter"] = dictListProd;
                //CheckAllNodes(tvFiltering.Nodes);

            }
        }
        protected void BindData()
        {
            string txt = Request.Params["searchtext"];
            if(txt == "All")
                dt1 = objProductListingBLClass.ShowAll();
            else
                dt1 = objProductListingBLClass.ShowProductListing(txt);
           
            dlProductListing.DataSource = dt1;
            dlProductListing.DataBind();
        }

        
        protected void dlProductListing_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void imProductListing_Click(object sender, DataListCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "ImageClick")
                {
                    string imgurl = e.CommandArgument.ToString().Trim().Split('/').Last(); /*   Getting image Url   */
                    dt = objBusinessLayerClass.productId(imgurl);
                    if (dt.Rows.Count > 0)
                        Response.Redirect("~/Transaction/AddToCart.aspx");
                    else
                        Response.Redirect("~/ProductListing/ProductListing.aspx");
                }
            }
        }
        protected void tvFiltering_OnTreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            TreeNode tn = sender as TreeNode;

            string selectedNodeText = e.Node.Text;
            string selectedNodeValue = e.Node.Value;

            tn = e.Node;
            //if (Session["listproductFilter"]!=null)
            //{ }

            if (e.Node.Checked == true)
            {
                CheckAllNodes(tn.ChildNodes);
                foreach (TreeNode oSubNode in tn.ChildNodes)
                {
                    dictListProd = Session["listproductFilter"] as Dictionary<string, string>;
                    if (!dictListProd.ContainsKey(oSubNode.Value))
                        dictListProd.Add(oSubNode.Value, oSubNode.Text);
                    foreach (TreeNode leaf in oSubNode.ChildNodes)
                    {
                        if (!dictListProd.ContainsKey(leaf.Value))
                            dictListProd.Add(leaf.Value, leaf.Text);
                    }
                }

                dictListProd = Session["listproductFilter"] as Dictionary<string, string>;
                if (!dictListProd.ContainsKey(selectedNodeValue))
                    dictListProd.Add(selectedNodeValue, selectedNodeText);
                Session["listproductFilter"] = dictListProd;
                if (dictListProd.Count > 0)
                {
                    dt3 = objProductListingBLClass.filter(dictListProd);
                    dlProductListing.DataSource = dt3;
                    dlProductListing.DataBind();
                }

                else
                    Response.Redirect("~/ProductListing/ProductListing.aspx");
            }
            else
            {
                UncheckAllNodes(tn.ChildNodes);
                foreach (TreeNode oSubNode in tn.ChildNodes)
                {
                    dictListProd = Session["listproductFilter"] as Dictionary<string, string>;
                    if (dictListProd.ContainsKey(oSubNode.Value))
                        dictListProd.Remove(oSubNode.Value);
                    foreach (TreeNode leaf in oSubNode.ChildNodes)
                    {
                        if (dictListProd.ContainsKey(leaf.Value))
                            dictListProd.Remove(leaf.Value);
                    }
                }

                dictListProd = Session["listproductFilter"] as Dictionary<string, string>;
                if (dictListProd.ContainsKey(selectedNodeValue))
                    dictListProd.Remove(selectedNodeValue);
                Session["listproductFilter"] = dictListProd;
                if (dictListProd.Count > 0)
                {
                    dt3 = objProductListingBLClass.filter(dictListProd);
                    dlProductListing.DataSource = dt3;
                    dlProductListing.DataBind();
                }

            }
        }


        protected void tvFiltering_OnSelectedNodeCheckChanged(object sender, EventArgs e)
        {

        }
        void Select_Change(Object sender, EventArgs e)
        {
            Label1.Text = "You selected: " + tvFiltering.SelectedNode.Text;
        }

        public void CheckAllNodes(TreeNodeCollection nodes) /* All Node Checked Default */
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }

        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.ChildNodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
    }
}