using System;
using System.Collections.Generic;
using System.Text;
	
namespace Framework.Web
{
    public class WebFormApplicationButtonRolePermission
    {
        string m_ButtonCommandName;
        public string ButtonCommandName
        {
            get { return m_ButtonCommandName; }
            set { m_ButtonCommandName = value; }
        }

        string m_ContainerIdentifier;
        public string ContainerIdentifier
        {
            get { return m_ContainerIdentifier; }
            set { m_ContainerIdentifier = value; }
        }

        List<string> m_EnabledByRoleList;

        public List<string> EnabledByRoleList
        {
            get { return m_EnabledByRoleList; }
            set { m_EnabledByRoleList = value; }
        }

        List<string> m_VisibleByRoleList;
        public List<string> VisibleByRoleList
        {
            get { return m_VisibleByRoleList; }
            set { m_VisibleByRoleList = value; }
        }

        List<string> m_DisabledByRoleList;
        public List<string> DisabledByRoleList
        {
            get { return m_DisabledByRoleList; }
            set { m_DisabledByRoleList = value; }
        }
        List<string> m_InvisibleByRoleList;

        public List<string> InvisibleByRoleList
        {
            get { return m_InvisibleByRoleList; }
            set { m_InvisibleByRoleList = value; }
        }

    }

    public class WebFormApplicationButtonRolePermissionCollection
        : List<Framework.Web.WebFormApplicationButtonRolePermission>
    {
        Framework.Web.WebFormApplicationButtonRolePermission m_ConditionInputItem = new Framework.Web.WebFormApplicationButtonRolePermission();


        //
        private bool PredicateByCommandNameAndContainerIdentifier(
            Framework.Web.WebFormApplicationButtonRolePermission item)
        {
            return (this.m_ConditionInputItem.ContainerIdentifier == item.ContainerIdentifier || this.m_ConditionInputItem.ContainerIdentifier == "*" )&&
                (this.m_ConditionInputItem.ButtonCommandName == item.ButtonCommandName || this.m_ConditionInputItem.ButtonCommandName == "*");
        }

        public Framework.Web.WebFormApplicationButtonRolePermission FindByCommandNameAndContainerIdentifier(
            string buttonCommandName, string containerIdentifier)
        {
            this.m_ConditionInputItem.ButtonCommandName = buttonCommandName;
            this.m_ConditionInputItem.ContainerIdentifier = containerIdentifier;

            return this.Find(this.PredicateByCommandNameAndContainerIdentifier);
        }

        public List<Framework.Web.WebFormApplicationButtonRolePermission> FindAllByCommandNameAndContainerIdentifier(
            string buttonCommandName, string containerIdentifier)
        {
            this.m_ConditionInputItem.ButtonCommandName = buttonCommandName;
            this.m_ConditionInputItem.ContainerIdentifier = containerIdentifier;

            return this.FindAll(this.PredicateByCommandNameAndContainerIdentifier);
        }

        public bool ExistsByCommandNameAndContainerIdentifier(
            string buttonCommandName, string containerIdentifier)
        {
            this.m_ConditionInputItem.ButtonCommandName = buttonCommandName;
            this.m_ConditionInputItem.ContainerIdentifier = containerIdentifier;

            return this.Exists(this.PredicateByCommandNameAndContainerIdentifier);
        }
    }
}