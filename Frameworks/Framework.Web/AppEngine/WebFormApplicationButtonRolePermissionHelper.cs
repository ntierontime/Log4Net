using System;
using System.Collections.Generic;
using System.Text;
	
namespace Framework.Web
{
    public class WebFormApplicationButtonRolePermissionHelper
    {
        Framework.Web.WebFormApplicationButtonRolePermissionCollection m_ButtonRolePermissionList;

        public Framework.Web.WebFormApplicationButtonRolePermissionCollection ButtonRolePermissionList
        {
            get { return m_ButtonRolePermissionList; }
            set { m_ButtonRolePermissionList = value; }
        }

        public bool IsAButtonEnabled(string buttonCommandName, string containerIdentifier, List<string> currentUserRoles)
        {
            string _containerIdentifier = System.IO.Path.GetFileName(containerIdentifier);

            bool _retval = true;
            if (this.m_ButtonRolePermissionList != null)
            {
                Framework.Web.WebFormApplicationButtonRolePermission _ButtonRolePermission = this.m_ButtonRolePermissionList.FindByCommandNameAndContainerIdentifier(
                    buttonCommandName, _containerIdentifier);
                if (_ButtonRolePermission != null && _ButtonRolePermission.DisabledByRoleList != null)
                {
                    foreach (string _CurrentUserRole in currentUserRoles)
                    {
                        if (true == _ButtonRolePermission.DisabledByRoleList.Contains(_CurrentUserRole))
                        {
                            _retval = false;
                            break;
                        }
                    }
                    if (_retval == false && _ButtonRolePermission.EnabledByRoleList != null)
                    {
                        foreach (string _CurrentUserRole in currentUserRoles)
                        {
                            if (true == _ButtonRolePermission.EnabledByRoleList.Contains(_CurrentUserRole))
                            {
                                _retval = true;
                                break;
                            }
                        }
                    }
                }
            }

            return _retval;
        }

        public bool IsAButtonVisible(string buttonCommandName, string containerIdentifier, List<string> currentUserRoles)
        {
            string _containerIdentifier = System.IO.Path.GetFileName(containerIdentifier);
            bool _retval = true;
            if (this.m_ButtonRolePermissionList != null)
            {
                Framework.Web.WebFormApplicationButtonRolePermission _ButtonRolePermission = this.m_ButtonRolePermissionList.FindByCommandNameAndContainerIdentifier(
                    buttonCommandName, _containerIdentifier);
                if (_ButtonRolePermission != null && _ButtonRolePermission.InvisibleByRoleList != null)
                {
                    foreach (string _CurrentUserRole in currentUserRoles)
                    {
                        if (true == _ButtonRolePermission.InvisibleByRoleList.Contains(_CurrentUserRole))
                        {
                            _retval = false;
                            break;
                        }
                    }
                    if (_retval == false && _ButtonRolePermission.VisibleByRoleList != null)
                    {
                        foreach (string _CurrentUserRole in currentUserRoles)
                        {
                            if (true == _ButtonRolePermission.VisibleByRoleList.Contains(_CurrentUserRole))
                            {
                                _retval = true;
                                break;
                            }
                        }
                    }
                }
            }

            return _retval;
        }
    }

    public class WebFormApplicationButtonRolePermissionHelperSingleton
        : Framework.Singleton<Framework.Web.WebFormApplicationButtonRolePermissionHelper>
    {
    }
}