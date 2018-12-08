using EADP_Project.DAO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.BO
{
    public class ConsentFormBO
    {
        public void createConsentForm(String senderID, String RecievingClasses, String School, String Title, String Description, String FoodPreferrence)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            consentformdao.createConsentForm(senderID, RecievingClasses, School, Title, Description, FoodPreferrence);
        }
        public void createConsentFormDraft(String senderID, String RecievingClasses, String School, String Title, String Description, String FoodPreferrence)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            consentformdao.createConsentFormDraft(senderID, RecievingClasses, School, Title, Description, FoodPreferrence);
        }
        public void createFormEntry(String SenderID, String FormID, String FoodPreferrence)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            consentformdao.createFormEntry(SenderID, FormID, FoodPreferrence);
        }
        public List<ConsentForm> getConsentFormsBySenderID(String senderID)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.getConsentFormsBySenderID(senderID); //getRecords
            
        }
        public List<ConsentForm> getDraftConsentFormsBySenderID(String senderID)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.getDraftConsentFormsBySenderID(senderID); //getRecords

        }
        public ConsentForm getConsentFormByFormID(String FormID)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.getConsentFormByFormID(FormID); 
        }
        public ConsentForm getDraftConsentFormByFormID(String FormID)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.getDraftConsentFormByFormID(FormID);
        }

        public void updateDraftConsentFormByFormID(String FormID, String RecievingClasses, String Title, String Description, String FoodPreferrence)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            consentformdao.updateDraftConsentFormByFormID(FormID, RecievingClasses, Title, Description, FoodPreferrence);
        }

        public List<ConsentForm> selectUnsignedFormsByUser(String UserID, String School, String Class)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.selectUnsignedFormsByUser(UserID, School, Class); //getRecords
        }

        public List<FormStatus> retrieveClassList(String FormID, String Education_Class, String Education_School)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.retrieveClassList(FormID, Education_Class, Education_School); //getRecords
        }
        public List<String> getSentClassesByFormID(String FormID)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            return consentformdao.getSentClassesByFormID(FormID); //getRecords
        }
        public void removeDraft(String draftID)
        {
            ConsentFormDAO consentformdao = new ConsentFormDAO();
            consentformdao.removeDraft(draftID); 
        }
    }
}