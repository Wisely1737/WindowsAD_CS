using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//****自己宣告(加入)*********************************
using System.DirectoryServices;  //自己 [加入參考] 才行
//**************************************************


public partial class Default_03_LDAP_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryEntry ent = new DirectoryEntry();

        DirectoryEntry ou = ent.Children.Find("OU=Consulting");
        // 取得 Active Directory網域服務階層架構中這個節點的「子項目」。
        // http://msdn.microsoft.com/zh-tw/library/system.directoryservices.directoryentry.children%28v=vs.100%29.aspx


        // Use the Add method to add a user to an organizational unit.
        // http://msdn.microsoft.com/zh-tw/library/system.directoryservices.directoryentries.add%28v=vs.100%29.aspx
        DirectoryEntry usr = ou.Children.Add("CN=New User", "user");

        // Set the samAccountName, then commit changes to the directory.
        usr.Properties["samAccountName"].Value = "newuser";

        usr.CommitChanges();
        // 根據預設值，變更是在本機快取上完成。在修改或加入節點之後，
        // 您必須呼叫 .CommitChanges()方法來認可您的變更，以便讓它們儲存到樹狀結構中。
    }

    //************************************************************************
    //** 資料來源  http://msdn.microsoft.com/zh-tw/library/ms180913%28v=vs.90%29.aspx
    //
    // 兩種寫法都一樣。例如 mydev.mydivision.fabrikam.com 
    // 或是 DC=mydev, DC=mydivision, DC=Fabrikam, DC=COM
    // ActiveDs.ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE值需要引用库才可使用；
    // 引用COM组件：Active DS Type Library
    //************************************************************************
    protected void Button1_Click(object sender, EventArgs e)
    {  // 啟用（Enable）帳號
        // 若要啟用使用者帳戶，必須移除使用者物件之 userAccountControl 屬性的 ADS_UF_ACCOUNTDISABLE旗標 (= 2)。
        // 旗標請參閱 http://msdn.microsoft.com/zh-tw/library/windows/desktop/aa772300%28v=vs.85%29.aspx
        DirectoryEntry usr =  new DirectoryEntry("LDAP://CN=New User,CN=users,DC=fabrikam,DC=com");
        int val = (int)usr.Properties["userAccountControl"].Value;

        usr.Properties["userAccountControl"].Value = val & ~((int)ActiveDs.ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE);

        usr.CommitChanges();
        //參考資料 http://hi.baidu.com/naobaihui/item/0bf456893945bfd35f0ec13c

        Response.Write("<h3>啟用（Enable）帳號</h3>");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {  // 停用（Disable）帳號
        DirectoryEntry usr = new DirectoryEntry("LDAP://CN=Old User,CN=users,DC=fabrikam,DC=com");
        int val = (int)usr.Properties["userAccountControl"].Value;

        usr.Properties["userAccountControl"].Value = val | ((int)ActiveDs.ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE);
        usr.CommitChanges();

        Response.Write("<h3>停用（Disable）帳號</h3>");
    }
}