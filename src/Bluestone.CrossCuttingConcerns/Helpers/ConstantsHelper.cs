using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.CrossCuttingConcerns.Helpers
{
    public static class ConstantsHelper
    {

        public static class Result
        {
            public const string Success = "success";
            public const string Failure = "failure";
        }

        public static class Messages
        {

        }

        public static class Success
        {
        }

        public static class Errors
        {
            public const string GeneralError = "Something went wrong! Please wait a moment and try again.";
            public const string MissingUsernameOrPasswordError = "Username or Password does not exist.";
            public const string InCorrectPasswordError = "Oops, please enter correct password.";
        }



        public static class Roles
        {
            //Role Added for Home
            public const string ALLOWHOMETABVIEW = "AllowHomeTabView";
            public const string ALLOWHOMETABEDIT = "AllowHomeTabEdit";
            public const string ALLOWINBOXTABVIEW = "AllowInboxTabView";
            public const string ALLOWDETAILTABVIEW = "AllowDetailTabView";
            public const string ALLOWCALENDARTABVIEW = "AllowCalendarTabView";
            public const string ALLOWFILECABINETTABVIEW = "AllowFileCabinetTabView";
            public const string AllowImpersonation = "AllowImpersonation";
            public const string AllowFileDelete = "AllowFileDelete";
            public const string MASTERPATIENTINDEX = "masterPatientIndex";
            public const string AllowServiceRequest = "AllowServiceRequest";
            public const string AllowEditDemographics = "AllowEditDemographics";
            public const string AllowAddPatientContact = "AllowAddPatientContact";
            public const string AllowINRAccess = "AllowINRAccess";

            //Permission for home toolbar
            public const string AllowHCHProfileAccess = "AllowHCHProfileAccess";
            public const string AllowCPOTimeTrack = "AllowCPOTimeTrack";
            public const string AllowProgressNotesView = "AllowProgressNotesView";

            //Role Added for Patients
            public const string AllowPatientsAdd = "AllowPatientsAdd";
            public const string AllowAllPatientView = "AllowAllPatientView";
            public const string AllowAllPatientEdit = "AllowAllPatientEdit";
            public const string VIEWPATIENTLIST = "AllowPatientView";
            public const string AllowPatientEdit = "AllowPatientEdit";
            public const string AllowPatientsTabView = "AllowPatientsTabView";
            public const string AllowManagePatientView = "AllowManagePatientView";
            public const string AllowPatientFaceSheetView = "AllowPatientFaceSheetView";
            public const string AllowAddProgressNoteView = "AllowAddProgressNoteView";
            public const string AllowGeneralInformationView = "AllowGeneralInformationView";
            public const string AllowPastMessagesView = "AllowPastMessagesView";
            public const string AllowCPOOversightAdd = "AllowCPOOversightAdd";
            public const string AllowAccessRequest = "AllowAccessRequest";

            //Role added for facility tab
            public const string FacilityManager = "FacilityManager";
            public const string AllowFacilitiesView = "AllowFacilitiesView";
            public const string AllowFacilitiesEdit = "AllowFacilitiesEdit";
            public const string AllowFacilitiesTabView = "AllowFacilitiesTabView";
            public const string AllowFacilityAdd = "AllowFacilityAdd";
            public const string AllowAllFacilityView = "AllowAllFacilityView";
            public const string AllowAllFacilityEdit = "AllowAllFacilityEdit";
            public const string AllowFacilityGeneralInformationTabView = "AllowFacilityGeneralInformationTabView";
            public const string AllowFacilityPatientTabView = "AllowFacilityPatientTabView";
            public const string AllowStaffTabView = "AllowStaffTabView";
            public const string AllowSubGroupsTabView = "AllowSubGroupsTabView";
            public const string AllowFacilityGeneralInformationEdit = "AllowFacilityGeneralInformationEdit";
            public const string AllowSubGroupAdd = "AllowSubGroupAdd";
            public const string AllowSubGroupEdit = "AllowSubGroupEdit";
            public const string IsProvider = "IsProvider";

            //Role Added for member
            public const string AllowMemberAdd = "AllowMemberAdd";
            public const string AllowMemberView = "AllowMemberView";
            public const string AllowMemberEdit = "AllowMemberEdit";
            public const string AllowMemberTabView = "AllowMemberTabView";
            public const string AllowMemberGeneralInformationTabView = "AllowMemberGeneralInformationTabView";
            public const string AllowManagePasswordTabView = "AllowManagePasswordTabView";
            public const string AllowUserTypeTabView = "AllowUserTypeTabView";
            public const string AllowCpoEligibilityTabView = "AllowCpoEligibilityTabView";
            public const string AllowMemberPatientTabView = "AllowMemberPatientTabView";
            public const string AllowLoginHistoryTabView = "AllowLoginHistoryTabView";
            public const string AllowMemberGeneralInformationEdit = "AllowMemberGeneralInformationEdit";
            public const string AllowUserTypeEdit = "AllowUserTypeEdit";
            public const string AllowCpoEligibilityEdit = "AllowCpoEligibilityEdit";
            public const string AllowChangePassword = "AllowChangePassword";

            //Role Added for Administration
            public const string AllowAdministratorTabView = "AllowAdministratorTabView";
            public const string AllowUserGroupsTabView = "AllowUserGroupsTabView";
            public const string AllowSecurityParmissionsTabView = "AllowSecurityParmissionsTabView";
            public const string AllowCareCoordinationTabView = "AllowCareCoordinationTabView";
            public const string AllowManageRoleGroupsView = "AllowManageRoleGroupsView";
            public const string AllowMapGroupRolesView = "AllowMapGroupRolesView";
            public const string AllowBulkAssignPatientsView = "AllowBulkAssignPatientsView";
            public const string AllowManageEnrollmentsView = "AllowManageEnrollmentsView";
            public const string AllowAssignPatientsView = "AllowAssignPatientsView";
            public const string AllowUserGroupAdd = "AllowUserGroupAdd";
            public const string AllowUserGroupEdit = "AllowUserGroupEdit";
            public const string AllowUserGroupRemove = "AllowUserGroupRemove";
            public const string AllowRoleGroupAdd = "AllowRoleGroupAdd";
            public const string AllowRoleGroupEdit = "AllowRoleGroupEdit";
            public const string AllowRoleGroupRemove = "AllowRoleGroupRemove";
            public const string AllowOrdersAccess = "AllowOrdersAccess";

            //Role added for File Message Section
            public const string AllowFileForNoOneElse = "AllowFileForNoOneElse";
            public const string AllowFileForEveryoneElse = "AllowFileForEveryoneElse";
            public const string AllowFileForMyTeam = "AllowFileForMyTeam";
            public const string AllowFileForFacility = "AllowFileForFacility";
            public const string AlllowFileForUserType = "AlllowFileForUserType";
            public const string AllowFileForSpecificUser = "AllowFileForSpecificUser";
            public const string AllowSaveSelectionAsDefault = "AllowSaveSelectionAsDefault";
            public const string AllowFileMessageAndClose = "AllowFileMessageAndClose";

            //  public const string AllowFileMessage = "AllowFileMessage";
            public const string AllowUrgentMessage = "AllowUrgentMessage";
            public const string AllowMessageFiling = "AllowMessageFiling";

            //Role for CCD Section
            public const string AllowPatientCCDAccess = "AllowPatientCCDAccess";

            //Role to override message status while creating new message
            public const string AllowNewMsgStatusOverride = "AllowNewMsgStatusOverride";

            //Role to override message status while existing message
            public const string AllowNextMsgStatusOverride = "AllowNextMsgStatusOverride";

            //editable announcement section on the Home tab, where a content administrator who has the "AllowAnnouncementEdit" permission can edit the page.
            public const string AllowAnnouncementEdit = "AllowAnnouncementEdit";

            //Role to allow user to forward the message
            public const string AllowMessageForward = "AllowMessageForward";

            //Role to allow visibility of Do List tab to the user
            public const string AllowInboxDoList = "AllowInboxDoList";

            //Role to allow visibility of In Progress tab to the user
            public const string AllowInboxInProgress = "AllowInboxInProgress";

            //Role to allow visibility of Completed tab to the user
            public const string AllowInboxCompleted = "AllowInboxCompleted";

            //Role to allow visibility of Sent tab to the user
            public const string AllowInboxSent = "AllowInboxSent";

            //Role to allow visibility of "Hidden" tab to the user
            public const string AllowInboxHidden = "AllowInboxHidden";
            public const string AllowCCMTimeTrackForMsgReview = "AllowCCMTimeTrackForMsgReview";
            public const string AllowAccessRequestWithOrder = "AllowAccessRequestWithOrder";
            public const string AllowFilterDoList = "AllowFilterDoList";
            public const string AllowFilterBySenderDoList = "AllowFilterBySenderDoList";
            public const string AllowSystemMessage = "AllowSystemMessage";
            public const string AllowINRDCManagement = "AllowINRDCManagement";
        }


    }
}
