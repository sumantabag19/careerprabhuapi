using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerPrahuWebAPI.AppData
{
    public class APIResponse
    {
        public bool status { get; set; }
        public DataTable data { get; set; }
        public string message { get; set; }
    }

    public class APIRegistrationData
    {
        public bool status { get; set; }
        public string message { get; set; }
        
    }

    //Registration dropdown response start

        //Class for state bind start
    public class StateResponse
    {
        public bool status { get; set; }
        public List<StateDetail> data { get; set; }
        public string message { get; set; }
    }
    public class StateDetail
    {
        public Int32 stateid { get; set; }
        public string statename { get; set; }
    }

    public class CareerListingResponse
    {
        public bool status { get; set; }
        public List<CareerListingDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CareerListingDetail
    {
        public Int32 careerid { get; set; }
        public string career { get; set; }
    }


    //class state bind end

    //class for city bind start
    public class CityResponse
    {
        public bool status { get; set; }
        public List<CityDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CityDetail
    {
        public Int32 cityid { get; set; }
        public string cityname { get; set; }
        //public Int32 iscareer { get; set; }
      
    }

    //class for city bind end

        //classes for bind school start
    public class SchoolResponse
    {
        public bool status { get; set; }
        public List<SchoolDetail> data { get; set; }
        public string message { get; set; }
    }
    public class SchoolDetail
    {
        public Int32 schoolid { get; set; }
        public string schoolname { get; set; }
    }

    //class for bind school end

        //class for bind classes start
    public class ClassResponse
    {
        public bool status { get; set; }
        public List<ClassDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ClassDetail
    {
        public Int32 classid { get; set; }
        public string classname { get; set; }
    }
    //class for bind classes end



    //class for bind login type
    public class LoginTypeResponse
    {
        public bool status { get; set; }
        public List<LoginTypeDetailsDetail> data1 { get; set; }
        public string message { get; set; }
    }
    public class LoginTypeDetailsDetail
    {
        public Int32 logintypeid { get; set; }
        public string logintypename { get; set; }
    }




    //class for bind stream start
    public class StreamResponse
    {
        public bool status { get; set; }
        public List<StreamDetail> data { get; set; }
        public string message { get; set; }
    }
    public class StreamDetail
    {
        public Int32 streamid { get; set; }
        public string streamname { get; set; }
    }
    //class for bind stream end

    public class LanguageResponse
    {
        public bool status { get; set; }
        public List<LanguageDetail> data { get; set; }
        public string message { get; set; }
    }
    public class LanguageDetail
    {
        public Int32 languageid { get; set; }
        public string languagename { get; set; }
    }



    //registration response dropdown ends

    public class StudentRegistrationResponse
    {
        public bool status { get; set; }
        public RegisteredData data { get; set; }
        public string message { get; set; }
    }
    public class RegisteredData
    { }


    //prepratory material class for api
    //Prepratory material response


    public class PrepratoryCategoryResponse
    {
        public bool status { get; set; }
        public List<PrepratoryCategoryDetail> data { get; set; }
        public string message { get; set; }
    }
    public class PrepratoryCategoryDetail
    {
        public Int32 prepid { get; set; }
        public string categoryname { get; set; }
        public string logo1 { get; set; }
        public string logo2 { get; set; }

        //public string logo1_scholarship { get; set; }
        //public string logo2_scholarship { get; set; }

        //public string logo1_entrance { get; set; }
        //public string logo2_entrance { get; set; }

        //public string logo1_comp { get; set; }
        //public string logo2_comp { get; set; }

    }

    //class for show prepratory category after click
    public class PrepratoryTitleResponse
    {
        public bool status { get; set; }
        public List<PrepratoryTitleDetail> data { get; set; }
        public string message { get; set; }
        public Boolean iscareer { get; set; }

    }
    public class PrepratoryTitleDetail
    {
        public Int32 prepnameid { get; set; }
        public string prepname { get; set; }
        public string description { get; set; }

    }

    //class for get career detail
    public class CareerResponse
    {
        public bool status { get; set; }
        public List<CareerDetail> data { get; set; }
        public string message { get; set; }

    }
    public class CareerDetail
    {
        public Int32 careerid { get; set; }
        public string careername { get; set; }

    }

    //clas for filter prepratory title wrt career
    public class FilterPrepTitleResponse
    {
        public bool status { get; set; }
        public List<FilterPrepTitleDetail> data { get; set; }
        public string message { get; set; }

    }
    public class FilterPrepTitleDetail
    {
        public Int32 prepnameid { get; set; }
        public string prepname { get; set; }

    }

    //class for get prepratory material
    public class UploadMaterialResponse
    {
        public bool status { get; set; }
        public List<UploadMaterialDetail> data { get; set; }
        public string message { get; set; }

    }
    public class UploadMaterialDetail
    {
        public string pdfpath { get; set; }
        public string imagepath { get; set; }
        public string url { get; set; }

    }

    //class for download material
    public class DowloadMaterialResponse
    {
        public bool status { get; set; }
        public List<DownloadMaterialDetail> data { get; set; }
        public List<DownloadMaterialUrlDetail> data1 { get; set; }
        public string message { get; set; }

    }
    public class DownloadMaterialDetail
    {
        public string pdfpath { get; set; }
        public string imagepath { get; set; }
        public string url { get; set; }
       


    }

    public class DownloadMaterialUrlDetail
    {
    
        public string url { get; set; }
        public string name { get; set; }

    }

    //Api for login data
    public class LoginResponse
    {
        public bool Status { get; set; }
        public LoginDetail data { get; set; }
     
        public string Message { get; set; }

    }
   

    public class LoginDetail
    {

        public string Token { get; set; }
        public int studentid { get; set; }
        public string studentname { get; set; }
        public string mobileno { get; set; }
        public string p_user { get; set; }
        public string loginkey { get; set; }
        public Int32 logintype { get; set; }

        public int classid { get; set; }
        public string classname { get; set; }
        public Boolean ispassout { get; set; }
        public int usertype { get; set; }
        public int principalid { get; set; }
        public int stateid { get; set; }
        public int cityid { get; set; }
        public int schoolid { get; set; }
        public string schoolname { get; set; }
        public string schoollogo { get; set; }

        public int ispaid { get; set; }
        public int streamid { get; set; }
        public string streamname { get; set; }
        public int languageid { get; set; }


    }

    //Class for portfolio start
    //class for bind trait
    public class TraitResponse
    {
        public bool status { get; set; }
        public List<TraitDetail> data { get; set; }
        public string message { get; set; }
    }
    public class TraitDetail
    {
        public Int32 traitid { get; set; }
        public string trait { get; set; }
    }

    //class for show guideline
    public class GuidelineResponse
    {
        public bool status { get; set; }
        public List<GuidelineDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GuidelineDetail
    {
        public string countryname { get; set; }
        public string location { get; set; }
        public string universityname { get; set; }
        public string guideline { get; set; }
        public string link { get; set; }
    }

    public class FilterGuidelineResponse
    {
        public bool status { get; set; }
        public List<FilterGuidelineDetail> data { get; set; }
        public string message { get; set; }
    }
    public class FilterGuidelineDetail
    {
        public string countryname { get; set; }
        public string location { get; set; }
        public string universityname { get; set; }
        public string guideline { get; set; }
        public string link { get; set; }
    }

    //class for bind intrest for SOP
    public class SOPIntrestResponse
    {
        public bool status { get; set; }
        public List<SOPIntrestDetail> data { get; set; }
        public string message { get; set; }
    }
    public class SOPIntrestDetail
    {
        public Int32 intrestid { get; set; }
        public string intrestname { get; set; }
    }
    //class for get Sample SOP data
    public class SampleSOPResponse
    {
        public bool status { get; set; }
        public List<SampleSOPDetail> data { get; set; }
        public string message { get; set; }
    }
    public class SampleSOPDetail
    {
        public string title { get; set; }
        public string description { get; set; }
        
    }

    //class for get sample essay data
    public class SampleEssayResponse
    {
        public bool status { get; set; }
        public List<SampleEsssayDetail> data { get; set; }
        public string message { get; set; }
    }
    public class SampleEsssayDetail
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string filename { get; set; }

    }
    //class for bind country
    public class CountryResponse
    {
        public bool status { get; set; }
        public List<CountryDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CountryDetail
    {
        public Int32 countryid { get; set; }
        public string countryname { get; set; }
    }
    //class for bind university
    public class UniversityResponse
    {
        public bool status { get; set; }
        public List<UniversityDetail> data { get; set; }
        public string message { get; set; }
    }
    public class UniversityDetail
    {
        public Int32 universityid { get; set; }
        public string universityname { get; set; }
    }
    //class for bind draft
    public class DraftResponse
    {
        public bool status { get; set; }
        public List<DraftDetail> data { get; set; }
        public string message { get; set; }
    }
    public class DraftDetail
    {
        public Int32 draftid { get; set; }
        public string drafttype { get; set; }
    }

    //class for bind version
    public class VersionResponse
    {
        public bool status { get; set; }
        public List<VersionDetail> data { get; set; }
        public string message { get; set; }
    }
    public class VersionDetail
    {
        public Int32 versionid { get; set; }
        public string versiontype { get; set; }
    }
    //class for save essay
    public class EssayResponse
    {
        public bool status { get; set; }
        public EssayData data { get; set; }
        public string message { get; set; }
    }
    public class EssayData
    { }


    public class TestResponse
    {
        public bool status { get; set; }
        public TestData data { get; set; }
        public string message { get; set; }
        //public string link { get; set; }
        //public Int32 paymentstatus { get; set; }
    }
    public class TestData
    {
        public string uniqueid { get; set; }
        public Int32 studentid { get; set; }
    }


    public class PremiumProductResponse
    {
        public bool status { get; set; }
        public PremimProductData data { get; set; }
        public string message { get; set; }
        //public string link { get; set; }
        //public Int32 paymentstatus { get; set; }
    }
    public class PremimProductData
    {
        public string uniqueid { get; set; }
        public Int32 studentid { get; set; }
    }



    //Display essay data
    public class DisplayEssayResponse
    {
        public bool status { get; set; }
        public List<DisplayEssayDetail> data { get; set; }
        public string message { get; set; }
    }
    public class DisplayEssayDetail
    {
        public Int32 essayid { get; set; }
        public string draftid { get; set; }
        public string draft { get; set; }
        public string versionid { get; set; }
        public string version { get; set; }
        public string essaydetail { get; set; }
        

    }
    //class for edit write essay data
    public class EditEssayResponse
    {
        public bool status { get; set; }
        public EditEssayDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditEssayDetail
    {
        public Int32 essayid { get; set; }
        public string draftid { get; set; }
        public string draft { get; set; }
        public string versionid { get; set; }
        public string version { get; set; }
        public string essaydetail { get; set; }


    }


    public class FAQResponse
    {
        public bool status { get; set; }
        public List<FAQDetail> data { get; set; }
        public string message { get; set; }
    }
    public class FAQDetail
    {
 
        public Int32 faqid { get; set; }
        public string faq { get; set; }
        public string answer { get; set; }


    }


    public class SelfAnalysisResponse
    {
        public bool status { get; set; }
        public SelfAnalysisDetail data { get; set; }
        public string message { get; set; }
    }
    public class SelfAnalysisDetail
    {
    
        public string description { get; set; }
        public string instruction { get; set; }


    }

    public class FAQAnsResponse
    {
        public bool status { get; set; }
        public FAQAnsDetail data { get; set; }
        public string message { get; set; }
    }
    public class FAQAnsDetail
    {

        public Int32 faqid { get; set; }
        public string answer { get; set; }


    }


    public class FAQReportResponse
    {
        public bool status { get; set; }
        public FAQReportDetail data { get; set; }
        public string message { get; set; }
    }
    public class FAQReportDetail
    {

        public Int32 faqid { get; set; }
        public string question { get; set; }
        public string answer { get; set; }


    }



    //class for upate essay
    public class UpdateEssayResponse
    {
        public bool status { get; set; }
        public UpdateEssayData data { get; set; }
        public string message { get; set; }
    }
    public class UpdateEssayData
    { }

    //class for delete essay data
    public class DeleteEssayResponse
    {
        public bool status { get; set; }
        public DeleteEssayData data { get; set; }
        public string message { get; set; }
    }
    public class DeleteEssayData
    { }
    //class for display summer school data
    public class SummerSchoolResponse
    {
        public bool status { get; set; }
        public List<SummerSchoolDetail> data { get; set; }
        public string message { get; set; }
    }
    public class SummerSchoolDetail
    {
        public string countryname { get; set; }
        public string universityname { get; set; }
        public string location { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string topic { get; set; }

        public string fees { get; set; }
        public string intrest { get; set; }
        public string duration { get; set; }
        public string cityname { get; set; }
        public string applicationlink { get; set; }

    }

    //class for save write sop
    public class WriteSOPResponse
    {
        public bool status { get; set; }
        public WriteSOPData data { get; set; }
        public string message { get; set; }
    }
    public class WriteSOPData
    { }

    //class for display SOP data
    public class DisplayWriteSOPResponse
    {
        public bool status { get; set; }
        public List<DisplayWriteSOPDetail> data { get; set; }
        public string message { get; set; }
    }
    public class DisplayWriteSOPDetail
    {
        public Int32 sopid { get; set; }
        public string draftid { get; set; }
        public string draft { get; set; }
        public string versionid { get; set; }
        public string version { get; set; }
        public string essaydetail { get; set; }


    }

    //Classs for edit write sop data
    public class EditWriteSopResponse
    {
        public bool status { get; set; }
        public EditWriteSopDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditWriteSopDetail
    {
        public Int32 sopid { get; set; }
        public string draftid { get; set; }
        public string draft { get; set; }
        public string versionid { get; set; }
        public string version { get; set; }
        public string essaydetail { get; set; }


    }

    //class for update write sop data
    public class UpdateWriteSopResponse
    {
        public bool status { get; set; }
        public UpdateWriteSopData data { get; set; }
        public string message { get; set; }
    }
    public class UpdateWriteSopData
    { }

    //class for delete write sop data
    public class DeleteWriteSOpResponse
    {
        public bool status { get; set; }
        public DeleteWriteSopData data { get; set; }
        public string message { get; set; }
    }
    public class DeleteWriteSopData
    { }

    //class for life coaches start
    public class DisplayLifeCoachResponse
    {
        public bool status { get; set; }
        public List<DisplayLifeCoachDetail> data { get; set; }
        public string message { get; set; }
    }
    public class DisplayLifeCoachDetail
    {
        public Int32 topicid { get; set; }
        public string topicname { get; set; }
        


    }


    //class for life coaches details
    public class DisplayLifeCoachDetailResponse
    {
        public bool status { get; set; }
        public List<DisplayLifeCoach> data { get; set; }
        public string message { get; set; }
    }
    public class DisplayLifeCoach
    {
        public string filename { get; set; }
        public string link { get; set; }


    }
    //class for archive webinar
    public class ArchiveWebinarResponse
    {
        public bool status { get; set; }
        public List<ArchiveWebinarDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ArchiveWebinarDetail
    {
        
        public string ArchiveVideo { get; set; }
        public string Topic { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string videoduration { get; set; }
        public string thumbnails { get; set; }


    }
    //class for future webinar
    public class FutureWebinarResponse
    {
        public bool status { get; set; }
        public List<FutureWebinarDetail> data { get; set; }
        public string message { get; set; }
    }
    public class FutureWebinarDetail
    {

        public string FutureVideo { get; set; }
        public string Topic { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string thumbnails { get; set; }


    }

    //save summer school data
    public class SummerSchoolAPIResponse
    {
        public bool status { get; set; }
        public SummerSchoolAPIData data { get; set; }
        public string message { get; set; }
    }
    public class SummerSchoolAPIData
    { }

    //class for bind previous year paper name
    public class PrevYearNameResponse
    {
        public bool status { get; set; }
        public List<PrevYearNameDetail> data { get; set; }
        public string message { get; set; }

    }
    public class PrevYearNameDetail
    {
        public Int32 testnameid { get; set; }
        public string testname { get; set; }

    }

    //class for bind sample paper name
    public class SamplepaperNameResponse
    {
        public bool status { get; set; }
        public List<SamplePaperNameDetail> data { get; set; }
        public string message { get; set; }

    }
    public class SamplePaperNameDetail
    {
        public Int32 sampleid { get; set; }
        public string samplepapername { get; set; }

    }

    //class for get mock test paper name
    public class MockpaperNameResponse
    {
        public bool status { get; set; }
        public List<MockPaperNameDetail> data { get; set; }
        public string message { get; set; }

    }
    public class MockPaperNameDetail
    {
        public Int32 mockid { get; set; }
        public string mockname { get; set; }

    }

    //class for get adhoc paper name
    public class AdhocpaperNameResponse
    {
        public bool status { get; set; }
        public List<AdhocPaperNameDetail> data { get; set; }
        public string message { get; set; }

    }
    public class AdhocPaperNameDetail
    {
        public Int32 adhocid { get; set; }
        public string adhocname { get; set; }

    }

    //class for professional help master
    public class ProfessionalHelpResponse
    {
        public bool status { get; set; }
        public List<ProfessionalHelpDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ProfessionalHelpDetail
    {
        public string testimonials { get; set; }
        public string image { get; set; }



    }

    //class for profile builder start
    public class ClassTranscriptResponse
    {
        public bool status { get; set; }
        public List<ClassTranscriptDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ClassTranscriptDetail
    {
        public Int32 classid { get; set; }
        public string classname { get; set; }
        public Boolean isstream { get; set; } = false;
    }

    //class for bind stream for transcript
    public class TransciptStreamResponse
    {
        public bool status { get; set; }
        public List<TranscriptStreamDetail> data { get; set; }
        public string message { get; set; }
    }
    public class TranscriptStreamDetail
    {
        public Int32 streamid { get; set; }
        public string streamname { get; set; }
    }

    //class for save transcript data
    public class TranscriptAPIResponse
    {
        public bool status { get; set; }
        public TranscriptAPIData data { get; set; }
        public string message { get; set; }
    }
    public class TranscriptAPIData
    { }

    public class CVAPIResponse
    {
        public bool status { get; set; }
        public CVAPIData data { get; set; }
        public string message { get; set; }
    }
    public class CVAPIData
    { }


    //class for get transcript data
    public class GetTransciptResponse
    {
        public bool status { get; set; }
        public List<GetTranscriptDetail> data { get; set; }
       
        public string message { get; set; }
    }
    public class GetTranscriptDetail
    {
        public int transcriptid { get; set; }
        public string classname { get; set; }
        public string streamname { get; set; }
        public string avggrade { get; set; }
        public string avgper { get; set; }
        public string schoolname { get; set; }
        public string filename { get; set; }
        public List<GetTranscriptDetailDoc> data1 { get; set; }


    }

    public class GetTranscriptDetailDoc
    {
        public string file { get; set; }
        public string filename { get; set; }

    }

    public class GetStuCVResponse
    {
        public bool status { get; set; }
        public GetStuCVDetail data { get; set; }
        public GetStuCVbannerDetail banner { get; set; }

        public string message { get; set; }
        
    }
    public class GetStuCVDetail
    {
      
        public string filename { get; set; }

        public string cvlink { get; set; }
        public Int32 cvid { get; set; }

    }
    public class GetStuCVbannerDetail
    {

        public string banner { get; set; }


    }




    //class for edit transcript data
    public class EditTransciptResponse
    {
        public bool status { get; set; }
        public EditTranscriptDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditTranscriptDetail
    {
        public int transcriptid { get; set; }
        public int classid { get; set; }
        public string classname { get; set; }
        public int streamid { get; set; }
        public string streamname { get; set; }
        public string avggrade { get; set; }
        public string avgper { get; set; }
        public string schoolname { get; set; }
        public string filename { get; set; }

    }
    //class for update transcript data
    public class TranscriptAPIUpdateResponse
    {
        public bool status { get; set; }
        public TranscriptAPIUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class TranscriptAPIUpdateData
    { }

    //Class for delete transcript data
    public class DeleteTranscriptResponse
    {
        public bool status { get; set; }
        public DeleteTranscript data { get; set; }
        public string message { get; set; }
    }
    public class DeleteTranscript
    { }







    //class for Ecp starts here
    public class ECPAPIResponse
    {
        public bool status { get; set; }
        public EcpAPIData data { get; set; }
        public string message { get; set; }
    }
    public class EcpAPIData
    { }

    //class for get ecp response
    public class GetECPResponse
    {
        public bool status { get; set; }
        public List<GetECPDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetECPDetail
    {
        public int ecpid { get; set; }
        public string topic { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string certificationfrom { get; set; }
        public string description { get; set; }
        public string learning { get; set; }
        public string filename { get; set; }
        public string originalfilename { get; set; }

    }

    public class EditECPResponse
    {
        public bool status { get; set; }
        public EditECPDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditECPDetail
    {
        public int ecpid { get; set; }
        
        public string topic { get; set; }
        
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string description { get; set; }
        public string certificatefrom { get; set; }
        public string learning { get; set; }
        

    }

    public class ECPAPIUpdateResponse
    {
        public bool status { get; set; }
        public ECPAPIUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class ECPAPIUpdateData
    { }

    public class DeleteECPResponse
    {
        public bool status { get; set; }
        public DeleteECP data { get; set; }
        public string message { get; set; }
    }
    public class DeleteECP
    { }

    public class GetECAResponse
    {
        public bool status { get; set; }
        public List<GetECADetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetECADetail
    {
        public int ecaid { get; set; }
        public string classname { get; set; }
        public string activityname { get; set; }
        public string level { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string achievement { get; set; }
        public string learning { get; set; }
        public string filename { get; set; }
        public string originalfilename { get; set; }


    }

    public class EditECAResponse
    {
        public bool status { get; set; }
        public EditECADetail data { get; set; }
        public string message { get; set; }
    }
    public class EditECADetail
    {
        public int ecaid { get; set; }
        public int classid { get; set; }
        public string classname { get; set; }
        public string activityname { get; set; }

        public string fromdate { get; set; }
        public string todate { get; set; }
        public Int32 level { get; set; }
        public string levelname { get; set; }
        public string achievement { get; set; }
        public string learning { get; set; }


    }

    public class ECAAPIUpdateResponse
    {
        public bool status { get; set; }
        public ECAAPIUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class ECAAPIUpdateData
    { }
    public class DeleteECAResponse
    {
        public bool status { get; set; }
        public DeleteECA data { get; set; }
        public string message { get; set; }
    }
    public class DeleteECA
    { }


    //class for social work starts here
    public class SocialWorkResponse
    {
        public bool status { get; set; }
        public SocialWorkData data { get; set; }
        public string message { get; set; }
    }
    public class SocialWorkData
    { }

    public class GetSocialWorkResponse
    {
        public bool status { get; set; }
        public List<GetSocialWorkDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetSocialWorkDetail
    {
        public int socialworkid { get; set; }
        public string classname { get; set; }
        public string socialwork { get; set; }
        public string description { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        
        public string learning { get; set; }
        public string filename { get; set; }
        public string originalfilename { get; set; }

    }

    public class EditSocialResponse
    {
        public bool status { get; set; }
        public EditSocialDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditSocialDetail
    {
        public int socialworkid { get; set; }
        public int classid { get; set; }
        public string classname { get; set; }
        public string socialwork { get; set; }
        public string description { get; set; }

        public string fromdate { get; set; }
        public string todate { get; set; }
        public string learning { get; set; }


    }

    public class SocialWorkUpdateResponse
    {
        public bool status { get; set; }
        public SocialWorkUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class SocialWorkUpdateData
    { }
    public class DeleteSocialResponse
    {
        public bool status { get; set; }
        public DeleteSocialWOrk data { get; set; }
        public string message { get; set; }
    }
    public class DeleteSocialWOrk
    { }


    //class for work experience starts here
    public class WorkExperienceResponse
    {
        public bool status { get; set; }
        public WorkExperienceData data { get; set; }
        public string message { get; set; }
    }
    public class WorkExperienceData
    { }
    public class GetWorExpResponse
    {
        public bool status { get; set; }
        public List<GetWorkExpDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetWorkExpDetail
    {
        public int workid { get; set; }
        public string projecttopic { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string companyname { get; set; }
        public string description { get; set; }
        public string learning { get; set; }
        public string filename { get; set; }
        public string originalfilename { get; set; }

    }
    public class EditWorkExpResponse
    {
        public bool status { get; set; }
        public EditWorkExpDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditWorkExpDetail
    {
        public int workid { get; set; }

        public string projecttopic { get; set; }

        public string fromdate { get; set; }
        public string todate { get; set; }
        public string description { get; set; }
        public string companyname { get; set; }
        public string learning { get; set; }


    }
    public class WorkExpUpdateResponse
    {
        public bool status { get; set; }
        public WorkExpUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class WorkExpUpdateData
    { }

    public class DeleteWorkExpResponse
    {
        public bool status { get; set; }
        public DeleteWorkExp data { get; set; }
        public string message { get; set; }
    }
    public class DeleteWorkExp
    { }

    public class GetSummerResponse
    {
        public bool status { get; set; }
        public List<GetSummerDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetSummerDetail
    {
        public int schoolid { get; set; }
        public string classname { get; set; }
        public string schoolname { get; set; }
        public string location { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string university { get; set; }
        public string descriptioin { get; set; }
        public string filename { get; set; }
        public string originalfilename { get; set; }


    }
    public class EditSummerResponse
    {
        public bool status { get; set; }
        public EditSummerDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditSummerDetail
    {
        public int schoolid { get; set; }
        public int classid { get; set; }
        public string classname { get; set; }
        public string schoolname { get; set; }

        public string fromdate { get; set; }
        public string todate { get; set; }
        public string location { get; set; }
        public string univercity { get; set; }
        public string description { get; set; }



    }
    public class SummerUpdateResponse
    {
        public bool status { get; set; }
        public SummerUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class SummerUpdateData
    { }

    public class DeleteSummerResponse
    {
        public bool status { get; set; }
        public DeleteSummer data { get; set; }
        public string message { get; set; }
    }
    public class DeleteSummer
    { }

    public class GetLevelResponse
    {
        public bool status { get; set; }
        public List<GetLevelDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetLevelDetail
    {
        public int levelid { get; set; }
        public string level { get; set; }
       

    }

    //class for ask query
    public class WriteQueryResponse
    {
        public bool status { get; set; }
        public WriteQueryData data { get; set; }
        public string message { get; set; }
    }
    public class WriteQueryData
    { }
    public class GetQueryResponse
    {
        public bool status { get; set; }
        public List<GetQueryDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetQueryDetail
    {
        public int queryid { get; set; }
        public int studentid { get; set; }
        public string ansquery { get; set; }
        public string query { get; set; }


    }
    public class IntrestResponse
    {
        public bool status { get; set; }
        public List<IntrestDetail> data { get; set; }
        public string message { get; set; }
    }
    public class IntrestDetail
    {
        public Int32 intrestid { get; set; }
        public string intrestname { get; set; }
    }


    public class UpcomingWebinarResponse
    {
        public bool status { get; set; }
        public UpcomingWebinarDetail data { get; set; }
        public string message { get; set; }
    }
    public class UpcomingWebinarDetail
    {

        public string timing { get; set; }
       


    }


    public class NotificationResponse
    {
        public bool status { get; set; }
        public List<NotificationDetail> data { get; set; }
        public string message { get; set; }
    }
    public class NotificationDetail
    {

        public string message { get; set; }
        public Int32 messageid { get; set; }
        


    }



    public class NotificationDetailResponse
    {
        public bool status { get; set; }
        public NotificationDetail_stu data { get; set; }
        public string message { get; set; }
    }
    public class NotificationDetail_stu
    {
        public string message { get; set; }
    }



    public class ProfessionalResponse
    {
        public bool status { get; set; }
        public List<ProfessionalDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ProfessionalDetail
    {
    
        public string testimonials { get; set; }      
       public string image { get; set; }
        public string name { get; set; }


    }
    public class LiveWebinarResponse
    {
        public bool status { get; set; }
        public int paidstatus { get; set; }
        public int isvideoavailable { get; set; }
        public int isupcomingwebinar { get; set; }
        public int isyoutubevideoavailable { get; set; }
        public int issubscriptionmessage { get; set; }
        public LiveWebinarDetail livewebinar { get; set; }
        public List<CareerGenieDetail> subscriptionmessage { get; set; }
        public UpcomingwebinarDetail upcomingwebinar { get; set; }
        public string message { get; set; }
        public string testlink { get; set; }
        public int ispermission { get; set; }

    }
    public class LiveWebinarDetail
    {
        public string livevideo { get; set; }
        public string livechat { get; set; }
        public string Topic { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string videoduration { get; set; }
        public string thumbnails { get; set; }

    }
    public class CareerGenieDetail
    {
      
        public string careergeniemessage { get; set; }
        public int messageid { get; set; }
        public int notificationtype { get; set; }


    }
    public class UpcomingwebinarDetail
    {

        public string timing { get; set; }


    }



    public class LogoutResponse
    {
        public bool status { get; set; }
        public LogoutDetail data { get; set; }
        public string message { get; set; }

    }
    public class LogoutDetail
    {
    }
    public class PrivacyResponse
    {
        public bool status { get; set; }
        public PrivacyDetail data { get; set; }
        public string message { get; set; }

    }
    public class PrivacyDetail
    {
        public string description { get; set; }
    }
    public class StudentResponse
    {
        public bool status { get; set; }
        public StudentDetail data { get; set; }
        public string message { get; set; }
    }
    public class StudentDetail
    {
        public string studentname { get; set; }
        public string mobileno { get; set; }
        public string email { get; set; }
        public int classid { get; set; }
        public string classname { get; set; }
        public int streamid { get; set; }
        public string streamname { get; set; }
        


    }
    public class FeedbackResponse
    {
        public bool status { get; set; }
        public FeedbackData data { get; set; }
        public string message { get; set; }
    }
    public class FeedbackData
    { }




    public class CountWebinarResponse
    {
        public bool status { get; set; }
        public List<CountWebinarDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CountWebinarDetail
    {

        public string date { get; set; }
        public string noofcount { get; set; }
       


    }
    public class PassoutResponse
    {
        public bool status { get; set; }
        public PassoutData data { get; set; }
        public string message { get; set; }
    }
    public class PassoutData
    { }

    public class OtpMatchResponse
    {
        public bool status { get; set; }
        public OtpMatchData data { get; set; }
        public string message { get; set; }
    }
    public class OtpMatchData
    { }


    public class MonthResponse
    {
        public bool status { get; set; }
        public List<MonthDetail> data { get; set; }
        public string message { get; set; }
    }
    public class MonthDetail
    {
        public Int32 monthid { get; set; }
        public string month { get; set; }
    }


    public class YearResponse
    {
        public bool status { get; set; }
        public List<YearDetail> data { get; set; }
        public string message { get; set; }
    }
    public class YearDetail
    {
        public Int32 yearid { get; set; }
        public string year { get; set; }
    }

    public class ChangeResponse
    {
        public bool status { get; set; }
        public ChangeData data { get; set; }
        public string message { get; set; }
    }
    public class ChangeData
    { }


    public class PreviousWebinarResponse
    {
        public bool status { get; set; }
        public PreviousWebinarDetail data { get; set; }
        public string message { get; set; }
    }
    public class PreviousWebinarDetail
    {
        public string previousvideo { get; set; }
        public string Topic { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string videoduration { get; set; }
    }

    public class GuidelineAPIResponse
    {
        public bool status { get; set; }
        public GuidelineDetailAPI data { get; set; }
        public string message { get; set; }
    }
    public class GuidelineDetailAPI
    {
     
        public string description { get; set; }
    }
    public class ProfileResponse
    {
        public bool status { get; set; }
        public ProfileDetail data { get; set; }
        public string message { get; set; }
    }
    public class ProfileDetail
    {
        public int id { get; set; }
        //public int studentid { get; set; }
        public string name { get; set; }
        public string schoolname { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public int stateid { get; set; }
        public int cityid { get; set; }
        public string classname { get; set; }
        public string streamname { get; set; }
        public int classid { get; set; }
        public int streamid{ get; set; }
        public string profilephoto { get; set; }
        public string principalname { get; set; }
        public Int32 languageid { get; set; }
        public string language { get; set; }
    }
    public class ProfileUpdateResponse
    {
        public bool status { get; set; }
        public ProfileUpdateData data { get; set; }
        public string message { get; set; }
    }
    public class ProfileUpdateData
    { }

    public class CoachTypeResponse
    {
        public bool status { get; set; }
        public List<CoachTypeDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CoachTypeDetail
    {
        public Int32 coachtypeid { get; set; }
        public string coachtype { get; set; }
    }




    public class CoachResponse
    {
        public bool status { get; set; }
        public List<CoachDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CoachDetail
    {
        public int coachid { get; set; }
        public string coachname { get; set; }
        public string description { get; set; }
       
        public string profilephoto { get; set; }
    }



    public class CoachInfoResponse
    {
        public bool status { get; set; }
        public CoachInfoDetail coachinfo { get; set; }
        public List<CoachCareerDetail> careerinfo { get; set; }
        public List<CoachInterviewDetail> coachinterviewinfo { get; set; }
        public List<CoachJourneyDetail> coachjourneyinfo { get; set; }
        public List<CoachArticleDetail> coacharticleinfo { get; set; }
        public string message { get; set; }

    }
    public class CoachInfoDetail
    {
        public string coachname { get; set; }
        public string profilepic { get; set; }
        public string description { get; set; }

        public string fbid { get; set; }
        public string linkedinid { get; set; }
        public string mobileno { get; set; }
        public string email { get; set; }
        public string coachtype { get; set; }

    }

    public class CoachCareerDetail
    {

        public string career { get; set; }


    }
    public class CoachInterviewDetail
    {

        public string interviewtitle { get; set; }
        public string interviewsubtitle { get; set; }
        public string interviewdocument { get; set; }

        public string videolink { get; set; }

    }
    public class CoachJourneyDetail
    {

        public string journeytitle { get; set; }
        public string journeysubtitle { get; set; }
        public string journeydocument { get; set; }

        public string videolink { get; set; }

    }
    public class CoachArticleDetail
    {

        public string articletitle { get; set; }
        public string articlesubtitle { get; set; }
        public string articledocument { get; set; }
        public string videolink { get; set; }


    }
    public class RepositoryResponse
    {
        public bool status { get; set; }
        public List<RepositoryDetail> data { get; set; }
 
        public string message { get; set; }
    }
    public class RepositoryDetail
    {
        public Int32 listingid { get; set; }
        public string heading { get; set; }
        public string listingimage { get; set; }
        public string videolink { get; set; }
    }


    public class ListingResponse
    {
        public bool status { get; set; }
        public ListingDetail data { get; set; }
        public string message { get; set; }
    }
    public class ListingDetail
    {
  
        public string listingpdf { get; set; }
        public string description { get; set; }

    }
    public class ArticleResponse
    {
        public bool status { get; set; }
        public List<ArticleDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ArticleDetail
    {
        public Int32 articleid { get; set; }
        public string heading { get; set; }
        public string articleimage { get; set; }
    }

    public class BlogResponse
    {
        public bool status { get; set; }
        public BlogDetail data { get; set; }
        public string message { get; set; }
    }
    public class BlogDetail
    {

        public string articlepdf { get; set; }
        public string description { get; set; }

    }
    public class AcademicResponse
    {
        public bool status { get; set; }
        public List<AcademicDetail> data { get; set; }
        public string message { get; set; }
    }
    public class AcademicDetail
    {
        public Int32 academicid { get; set; }
        public string academicyear { get; set; }
        
    }
    public class SavePlacementResponse
    {
        public bool status { get; set; }
        public SavePlacementData data { get; set; }
        public string message { get; set; }
    }
    public class SavePlacementData
    { }

    public class DisplayPlacementResponse
    {
        public bool status { get; set; }
        public List<DisplayPlacementDetail> data { get; set; }
        public string message { get; set; }
    }
    public class DisplayPlacementDetail
    {
        public Int32 placementid { get; set; } 
        public string studentname { get; set; }
        public string fathername { get; set; }
        public string mobileno { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }
        public string univercity { get; set; }
        public string college { get; set; }
        public string course { get; set; }
        public string specialization { get; set; }
        public string academicyear { get; set; }
        public string isdrop { get; set; }


    }
    public class EditPlacementResponse
    {
        public bool status { get; set; }
        public EditPlacementDetail data { get; set; }
        public string message { get; set; }
    }
    public class EditPlacementDetail
    {
        
        public Int32 placementid { get; set; }
        public string studentname { get; set; }
        public string fathername { get; set; }
        public string mobileno { get; set; }
        public int stateid { get; set; }
        public string statename { get; set; }
        public int cityid { get; set; }
        public string cityname { get; set; }
        public string univercity { get; set; }
        public string college { get; set; }
        public string course { get; set; }
        public string specialization { get; set; }
        public string academicyear { get; set; }
        public int isdrop { get; set; }
    }
    public class UpdatePlacementResponse
    {
        public bool status { get; set; }
        public UpdatePlacementData data { get; set; }
        public string message { get; set; }
    }
    public class UpdatePlacementData
    { }
    public class DeletePlacementResponse
    {
        public bool status { get; set; }
        public DeletePlacement data { get; set; }
        public string message { get; set; }
    }
    public class DeletePlacement
    { }
    public class ScholarshipResponse
    {
        public bool status { get; set; }
        public List<ScholarshipDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ScholarshipDetail
    {

        public string topic { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string url { get; set; }
    

    }
    public class EntranceResponse
    {
        public bool status { get; set; }
        public List<EntranceDetail> data { get; set; }
        public string message { get; set; }
    }
    public class EntranceDetail
    {
        public string examname { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string url { get; set; }

    }
    public class PlacementDatailsResponse
    {
        public bool status { get; set; }
        public List<PlacemetDetail> data { get; set; }
        public string message { get; set; }
    }
    public class PlacemetDetail
    {
        public string stream { get; set; }
        public string studentname { get; set; }
        public string fathername { get; set; }
        public string university { get; set; }
        public string college { get; set; }

    }

    public class CVResponse
    {
        public bool status { get; set; }
        public List<StudentCVDetail> studentinfo { get; set; }
        public List<TranscriptCVDetail> transcriptinfo { get; set; }
        public List<ECACVDetail> ecainfo { get; set; }
        public List<ECPCVDetail> ecpinfo { get; set; }
        public List<SocialCVDetail> socialinfo { get; set; }
        public List<WorkCVDetail> workinfo { get; set; }
        public List<SchoolCVDetail> summerschoolinfo { get; set; }
        public GenerateCVDetail GenCV { get; set; }
        public string message { get; set; }
    }
    public class StudentCVDetail
    {
        public string studentname { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public string academicyear { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }
        public string schoolname { get; set; }
        public string classname { get; set; }
        public string streamname { get; set; }

    }
    public class TranscriptCVDetail
    {
        public string schoolname { get; set; }
        public string grade { get; set; }
        public string percentage { get; set; }
        public string academicyear { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }
 

    }
    public class ECACVDetail
    {
        public string activityname { get; set; }
        public string level { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string achievement { get; set; }
        public string learning { get; set; }
        public string classname { get; set; }

    }
    public class ECPCVDetail
    {
        public string topic { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string certificatefrom { get; set; }
        public string desccription { get; set; }
        public string learning { get; set; }

    }
    public class SocialCVDetail
    {
        public string clasname { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string socialwork { get; set; }
        public string desccription { get; set; }
        public string learning { get; set; }

    }
    public class WorkCVDetail
    {
        public string companyname { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string projecttopic { get; set; }
        public string desccription { get; set; }
        public string learning { get; set; }

    }
    public class SchoolCVDetail
    {
        public string schoolname { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string state { get; set; }
        public string university { get; set; }
        public string description { get; set; }
        public string classname { get; set; }
    }

    public class GenerateCVResponse
    {
        public bool status { get; set; }
        public List<GenerateCVDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GenerateCVDetail
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string cv { get; set; }
    }
    public class CareerStateResponse
    {
        public bool status { get; set; }
        public List<CareerStateDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CareerStateDetail
    {
        public Int32 stateid { get; set; }
        public string statename { get; set; }
    }
    public class CareerCityResponse
    {
        public bool status { get; set; }
        public List<CareerCityDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CareerCityDetail
    {
        public Int32 cityid { get; set; }
        public string cityname { get; set; }
    }
    public class CareersubtraitResponse
    {
        public bool status { get; set; }
        public List<CareersubtraitDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CareersubtraitDetail
    {
        public Int32 subtraitid { get; set; }
        public string subtrait { get; set; }
    }


    public class ShowsubtraitResponse
    {
        public bool status { get; set; }
        public List<ShowsubtraitDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ShowsubtraitDetail
    {
        public string videolink { get; set; }
        public string image { get; set; }
        public string countryname { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }
        public string university { get; set; }
        public string guideline { get; set; }
        public string description { get; set; }
        public string trait { get; set; }
        public string subtrait { get; set; }
        public string originalfilename { get; set; }

    }
    public class ShowStuentResponse
    {
        public bool status { get; set; }
        public List<ShowStudentDetail> data { get; set; }
        public string message { get; set; }
    }
    public class ShowStudentDetail
    {
        public Int32 studentid { get; set; }
        public string studentname { get; set; }
    }
    public class ShowGuidelineResponse
    {
        public bool status { get; set; }
        public ShowGuidelineDetail data { get; set; }
        public string message { get; set; }
    }
    public class ShowGuidelineDetail
    {
        public string video { get; set; }
        public string pdf { get; set; }
        public string originalfilename { get; set; }

    }
    public class PremiumResponse
    {
        public bool status { get; set; }
        public List<PremiumDetail> data { get; set; }
        public BannerDetail banner { get; set; }
        
        public string message { get; set; }
    }
    public class PremiumDetail
    {
        public Int32 productid { get; set; }
        public string productname { get; set; }
        public Int32 status { get; set; }
        public string description { get; set; }

    }
  




    public class BannerDetail
    {
        
        public string banner { get; set; }
      

    }
    public class PrincipalLoginResponse
    {
        public bool Status { get; set; }
        public PrincipalLoginDetail data { get; set; }
        public string Message { get; set; }

    }
    public class PrincipalLoginDetail
    {
        public string Token { get; set; }
        public int principalid { get; set; }
        public string p_user { get; set; }
        public string loginkey { get; set; }
        public Int32 logintype { get; set; }

        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
        public Int32 schoolid { get; set; }
        public int usertype { get; set; }

    }



    public class GetTestResponse
    {
        public bool status { get; set; }
        public GetTestDetail data { get; set; }
        public string message { get; set; }
        public string Link { get; set; }
    }
    public class GetTestDetail
    {
        public string studentname { get; set; }
        public Int32 classid { get; set; }
        public string classname { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public Int32 stateid { get; set; }
        public string statename { get; set; }
        public Int32 cityid { get; set; }
        public string cityname { get; set; }
        public Int32 schoolid { get; set; }
        public string schoolname { get; set; }        
        public decimal actualprice { get; set; }
        public decimal conveniencefeed { get; set; }
        public decimal cgst { get; set; }
        public decimal sgst { get; set; }
        public decimal amounttobepaid { get; set; }
        public string referby { get; set; }
        public string isstatus { get; set; }
        public Int32 paymentstatus { get; set; }
    }





    public class GetPremiumResponse
    {
        public bool status { get; set; }
        public GetPremiumDetail data { get; set; }
        public  List<GetPremiumTestimonialsDetail> data1 { get; set; }
        public GetPremiumVideoPdfDetail data2 { get; set; }
        public string message { get; set; }
        public Int32 paidstatus { get; set; }

    }
    public class GetPremiumDetail
    {      
        public decimal actualprice { get; set; }
        public decimal conveniencefees { get; set; }       
        public decimal gst { get; set; }
        public decimal amounttobepaid { get; set; }

        public int discountpercentage { get; set; }
        public string couponname { get; set; }

        public decimal discountamount { get; set; }

        public decimal amountafterdiscount { get; set; }

        public decimal gstamount { get; set; }

    }
    public class GetPremiumTestimonialsDetail
    {
        public string description { get; set; }
        public string testimonials { get; set; }
        public string image { get; set; }
        public string profilephoto { get; set; }
        public string name { get; set; }
        public string link { get; set; }

    }

    public class GetPremiumVideoPdfDetail
    {
        public string videolink { get; set; }
        public string pdffile { get; set; }

        public string productdescription { get; set; }
    }





    public class GetTestStatusResponse
    {
        public bool status { get; set; }
        public List<GetTestStatusDetail> data { get; set; }
        public GetTestPercentageDetail data1 { get; set; }
        public string message { get; set; }
    }
    public class GetTestStatusDetail
    {
        public string studentname { get; set; }

        public string classname { get; set; }
        public string streamname { get; set; }
        public string emali { get; set; }


    }

    public class GetTestPercentageDetail
    {

        public decimal attendpercentage { get; set; }

        public decimal pendingpercentage { get; set; }

    }
    public class CollegeRepositoryResponse
    {
        public bool status { get; set; }
        public List<CollegRepositoryDetail> data { get; set; }
        public string message { get; set; }
    }
    public class CollegRepositoryDetail
    {

        public string description { get; set; }
        public string image { get; set; }
        public string collegename { get; set; }
        public string videolink { get; set; }

    }





    public class LoginResponse_google
    {
        public bool Status { get; set; }
        public LoginDetail_google data { get; set; }
        public int profilestatus { get; set; }
        public string Message { get; set; }

    }
   

    public class LoginDetail_google
    {

        public string Token { get; set; }
        public int studentid { get; set; }
        public string studentname { get; set; }
        public string mobileno { get; set; }
        public string p_user { get; set; }
        public string loginkey { get; set; }
        public Int32 logintype { get; set; }

        public int classid { get; set; }
        public string classname { get; set; }
        public Boolean ispassout { get; set; }
        public int usertype { get; set; }
        public int principalid { get; set; }
        public int stateid { get; set; }
        public int cityid { get; set; }
        public int schoolid { get; set; }
        public string schoolname { get; set; }
        public string schoollogo { get; set; }

        public int ispaid { get; set; }
        public int streamid { get; set; }
        public string streamname { get; set; }
        

    }



    public class GetFeedbackResponse
    {
        public bool status { get; set; }
        public List<GetFeedbackDetail> data { get; set; }
        public string message { get; set; }
    }
    public class GetFeedbackDetail
    {
        public int feedbackid { get; set; }
        public int studentid { get; set; }
        public string feedback { get; set; }
        public string feedbackreplay { get; set; }


    }





}
