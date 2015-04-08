﻿using ClinicWebForm.Classes;
using ClinicWebForm.Models;
using ClinicWebForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicWebForm.Controllers
{
    //[Authorize]
    public class HealthController : Controller
    {
        // GET: Health
        public ActionResult Index()
        {
            List<Health> healthList;
            using (var connection = AppUtils.GetOpenConnection())
            {
                string sql = "select top 100 * from main";
                healthList = Dapper.SqlMapper.Query<Health>(connection, sql).ToList();
            }

            return View("List", healthList);
        }

        // GET: Health/Details/5
        public ActionResult Details(int id)
        {
            Health health;
            using (var connection = AppUtils.GetOpenConnection())
            {
                string sql = "select * from main where Id = @Id";
                health = Dapper.SqlMapper.Query<Health>(connection, sql, new { Id = id }).ToList().First();
            }

            return View(health);
        }

        // GET: Health/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health/Create
        [HttpPost]
        public ActionResult Create(Health health)
        {
            try
            {
                using (var connection = AppUtils.GetOpenConnection())
                {
                    string sql = @"INSERT INTO main (OFFICIAL_HOUSE_REG_NO, CHW_ID_NO, DATE_OF_VISIT, CHW_NAME, DISTRICT, PROVINCE, WARD_DHIS, CLINIC_NAME, TEAM_NAME, HOUSEHOLD_HEAD_NAME, HOUSEHOLD_ADDRESS, HOUSEHOLD_HEAD_TEL, HOUSEHOLD_RESPONDENT, MEMBER_1_NAME, MEMBER_1_DOB, MEMBER_1_AGE, MEMBER_1_GENDER, MEMBER_2_NAME, MEMBER_2_AGE, MEMBER_2_DOB, MEMBER_2_GENDER	HOUSEHOLD_TOILET, MEMBER_3_NAME	MEMBER_3_DOB, MEMBER_3_AGE, MEMBER_3_GENDER, MEMBER_4_NAME, MEMBER_4_DOB, MEMBER_4_AGE, MEMBER_4_GENDER, MEMBER_5_NAME	MEMBER_5_DOB, MEMBER_5_AGE, MEMBER_5_GENDER, MEMBER_6_NAME, MEMBER_6_DOB, MEMBER_6_AGE, MEMBER_6_GENDER, MEMBER_7_NAME, MEMBER_7_DOB, MEMBER_7_AGE, MEMBER_7_GENDER, MEMBER_8_NAME, MEMBER_8_DOB, MEMBER_8_AGE, MEMBER_8_GENDER, HOUSEHOLD_NUMBER_OF_PEOPLE, ALL_HOUSEHOLD_MEMBERS_REGISTERED, HOUSEHOLD_ELECTRICITY, HOUSEHOLD_PUMPED_WATER, HOUSEHOLD_FRIDGE, HOUSEHOLD_ROOMS, HOUSEHOLD_GRANTS, HOUSEHOLD_MEMBERS_THAT_WORK, LEARNERS_SCHOOLS_1, LEARNERS_SCHOOLS_2, MEMBER_WITH_PERSISTANT_COUGH, MEMBER_WITH_NIGHT_SWEATS, MEMBER_WITH_WEIGHT_LOSS	MEMBER_WITH_FEVER, MEMBER_WITH_LOSS_OF_APPITITE, MEMBER_WITH_TB_SYMPTOMS, MEMBER_NEEDING_HIV_TEST, MEMBERS_WITH_SOCIAL_GRANTS, MEMBERS_APPLYING_FOR_GRANTS, MEMBER_WHO_WOULD_LIKE_HIV_TEST, MEMBER_NEEDING_FAMILY_PLANNING, MEMBER_WITH_UNMET_FAMILY_PLANNING_NEEDS, MEMBER_WHO_NEEDS_HELP_WITH_DAILY_ACTIVITES	MEMBER_THAT_NEEDS_ADL_HELP, HOUSEHOLD_CHILD_HEAD, AGE_OF_HOUSEHOLD_HEAD, HOUSEHOLD_PREGNANCY_OR_PERION_IN_6_WEEKS, MEMBERS_PREGNANT_IN_HOUSEHOLD, BABY_DELIVERIES_IN_PAST_6_WEEKS, NUMBER_OF_BABIES_IN_6_WEEKS, HOUSEHOLD_CHILDREN_UNDER_5, NUMBER_OF_CHILDREN_UNDER_5_IN_HOUSEHOLD, MEMBER_TAKING_MEDICATION, MEMBER_NUMBER_TAKING_CHRONIC_MEDICATION, NOTE_ON_HOUSEHOLD_SCREENING	FOLLOW_UP_DATE, PREGNANT_MEMBER_EXPECTED_DATE, MEMBER_NUMBER_CURRENTLY_PREGNANT, REFERALLS_ISSUED_FOR_PREGNANT_MEMBER, DOB_MEMBER_BORN_WITHIN_6_WEEKS, MEMBER_NUMBER_BORN_WITHIN_THE_LAST_6_WEEKS, BABY_WEIGHT_LESS_THAN_2500G, MEMBER_NUMBER_BIRTH_WEIGHT_LESS_THAN_2500g, NUMBER_OF_REFERRALS_FOR_UNDER_WEIGHT_BABIES, CHILRDEN_UNDER_5_NOT_IMMUNIZED, CHILDREN_UNDER_5_WITH_NO_VIT_A_IN_6_MONTHS, REFERRAL_FORMS_ISSUED_BABIES_BORN_WITHIN_6_WEEKS_IF_NECESSARY, MEMBER_NUMBER_WHOSE_IMMUNIZATION_IS_NOT_UP_TO_DATE, REFFERALS_ISSUED_FOR_CHILDREN_NOT_IMMUNIZED, MEMBER_NUMBER_NOT_HAD_VITAMIN_A_PROPHYLAXIS, CHILDREN_NOT_WEIGHED_OR_UNDER_WEIGHT, MEMBER_NUMBER_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION, CHILDREN_SUSPECTED_OF_ILLNESS_OR_CONCERNS, REFERRALS_FOR__VITAMIN_A_PROPHYLAXIS, REFFERALS_FOR_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION, MEMBER_NUMBER_SUSPECTED_OF_ILLNESS_OR_CONCERNS, REFFERALS_FOR_NOT_WEIGHED_CHILDREN_SHOWS_SIGNS_OF_MALNUTRITION, HIV_EXPOSED_CHILDREN_WITHIN_6_WEEKS, MEMBER_NUMBER_NOT_HAD_PCR__WHO_IS_6_WEEKS_AND_OLDER_HIV_EXPOSED, REFERRALS_FOR_HIV_EXPOSED_CHILDREN_6_WEEKS_OLDER_NOT__PCR_TEST, MEMBERS_TAKING_TB, HIV-BP-DIABETES_MEDS, MEMBER_NUMBER_TAKING_TB-HIV-BP-DIABETES_MEDS, REFERRALS_FOR_TAKING_TB-HIV-BP-DIABETES_MEDS, MEMBER_DEFAULTING_FROM_TREATMENT, MEMBER_NUMBER_THAT_DEFAULTED, REFERRALS_ISSUED_FOR_DEFAULTING_MEMBER, ANY_OTHER_PROBLEMS, MEMBER_NUMBER_WITH_IDENTIFIED_PROBLEMS, REFERRAL_FORMS_FOR_ANY_OTHER_PROBLEMS_IDENTIFIED, COMMENTS_LINE_1, COMMENTS_LINE_2, COMMENTS_LINE_3, COMMENTS_LINE_4, CHW_SIGN, TL_NAME, TL_VERIFY_DATE, F123) VALUES";
                    sql += "(@OFFICIAL_HOUSE_REG_NO,@CHW_ID_NO,@DATE_OF_VISIT,@CHW_NAME,@DISTRICT,@PROVINCE,@WARD_DHIS,@CLINIC_NAME,@TEAM_NAME,@HOUSEHOLD_HEAD_NAME,@HOUSEHOLD_ADDRESS,@HOUSEHOLD_HEAD_TEL,@HOUSEHOLD_RESPONDENT,@MEMBER_1_NAME,@MEMBER_1_DOB,@MEMBER_1_AGE,@MEMBER_1_GENDER,@MEMBER_2_NAME,@MEMBER_2_AGE,@MEMBER_2_DOB,@MEMBER_2_GENDER,@HOUSEHOLD_TOILET,@MEMBER_3_NAME,@MEMBER_3_DOB,@MEMBER_3_AGE,@MEMBER_3_GENDER,@MEMBER_4_NAME,@MEMBER_4_DOB,@MEMBER_4_AGE,@MEMBER_4_GENDER,@MEMBER_5_NAME,@MEMBER_5_DOB,@MEMBER_5_AGE,@MEMBER_5_GENDER,@MEMBER_6_NAME,@MEMBER_6_DOB,@MEMBER_6_AGE,@MEMBER_6_GENDER,@MEMBER_7_NAME,@MEMBER_7_DOB,@MEMBER_7_AGE,@MEMBER_7_GENDER,@MEMBER_8_NAME,@MEMBER_8_DOB,@MEMBER_8_AGE,@MEMBER_8_GENDER,@HOUSEHOLD_NUMBER_OF_PEOPLE,@ALL_HOUSEHOLD_MEMBERS_REGISTERED,@HOUSEHOLD_ELECTRICITY,@HOUSEHOLD_PUMPED_WATER,@HOUSEHOLD_FRIDGE,@HOUSEHOLD_ROOMS,@HOUSEHOLD_GRANTS,@HOUSEHOLD_MEMBERS_THAT_WORK,@LEARNERS_SCHOOLS_1,@LEARNERS_SCHOOLS_2,@MEMBER_WITH_PERSISTANT_COUGH,@MEMBER_WITH_NIGHT_SWEATS,@MEMBER_WITH_WEIGHT_LOSS,@MEMBER_WITH_FEVER,@MEMBER_WITH_LOSS_OF_APPITITE,@MEMBER_WITH_TB_SYMPTOMS,@MEMBER_NEEDING_HIV_TEST,@MEMBERS_WITH_SOCIAL_GRANTS,@MEMBERS_APPLYING_FOR_GRANTS,@MEMBER_WHO_WOULD_LIKE_HIV_TEST,@MEMBER_NEEDING_FAMILY_PLANNING,@MEMBER_WITH_UNMET_FAMILY_PLANNING_NEEDS,@MEMBER_WHO_NEEDS_HELP_WITH_DAILY_ACTIVITES,@MEMBER_THAT_NEEDS_ADL_HELP,@HOUSEHOLD_CHILD_HEAD,@AGE_OF_HOUSEHOLD_HEAD,@HOUSEHOLD_PREGNANCY_OR_PERION_IN_6_WEEKS,@MEMBERS_PREGNANT_IN_HOUSEHOLD,@BABY_DELIVERIES_IN_PAST_6_WEEKS,@NUMBER_OF_BABIES_IN_6_WEEKS,@HOUSEHOLD_CHILDREN_UNDER_5,@NUMBER_OF_CHILDREN_UNDER_5_IN_HOUSEHOLD,@MEMBER_TAKING_MEDICATION,@MEMBER_NUMBER_TAKING_CHRONIC_MEDICATION,@NOTE_ON_HOUSEHOLD_SCREENING,@FOLLOW_UP_DATE,@PREGNANT_MEMBER_EXPECTED_DATE,@MEMBER_NUMBER_CURRENTLY_PREGNANT,@REFERALLS_ISSUED_FOR_PREGNANT_MEMBER,@DOB_MEMBER_BORN_WITHIN_6_WEEKS,@MEMBER_NUMBER_BORN_WITHIN_THE_LAST_6_WEEKS,@BABY_WEIGHT_LESS_THAN_2500G,@MEMBER_NUMBER_BIRTH_WEIGHT_LESS_THAN_2500g,@NUMBER_OF_REFERRALS_FOR_UNDER_WEIGHT_BABIES,@CHILRDEN_UNDER_5_NOT_IMMUNIZED,@CHILDREN_UNDER_5_WITH_NO_VIT_A_IN_6_MONTHS,@REFERRAL_FORMS_ISSUED_BABIES_BORN_WITHIN_6_WEEKS_IF_NECESSARY,@MEMBER_NUMBER_WHOSE_IMMUNIZATION_IS_NOT_UP_TO_DATE,@REFFERALS_ISSUED_FOR_CHILDREN_NOT_IMMUNIZED,@MEMBER_NUMBER_NOT_HAD_VITAMIN_A_PROPHYLAXIS,@CHILDREN_NOT_WEIGHED_OR_UNDER_WEIGHT,@MEMBER_NUMBER_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION,@CHILDREN_SUSPECTED_OF_ILLNESS_OR_CONCERNS,@REFERRALS_FOR__VITAMIN_A_PROPHYLAXIS,@REFFERALS_FOR_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION,@MEMBER_NUMBER_SUSPECTED_OF_ILLNESS_OR_CONCERNS,@REFFERALS_FOR_NOT_WEIGHED_CHILDREN_SHOWS_SIGNS_OF_MALNUTRITION,@HIV_EXPOSED_CHILDREN_WITHIN_6_WEEKS,@MEMBER_NUMBER_NOT_HAD_PCR__WHO_IS_6_WEEKS_AND_OLDER_HIV_EXPOSED,@REFERRALS_FOR_HIV_EXPOSED_CHILDREN_6_WEEKS_OLDER_NOT__PCR_TEST,@MEMBERS_TAKING_TB,@HIV-BP-DIABETES_MEDS,@MEMBER_NUMBER_TAKING_TB-HIV-BP-DIABETES_MEDS,@REFERRALS_FOR_TAKING_TB-HIV-BP-DIABETES_MEDS,@MEMBER_DEFAULTING_FROM_TREATMENT,@MEMBER_NUMBER_THAT_DEFAULTED,@REFERRALS_ISSUED_FOR_DEFAULTING_MEMBER,@ANY_OTHER_PROBLEMS,@MEMBER_NUMBER_WITH_IDENTIFIED_PROBLEMS,@REFERRAL_FORMS_FOR_ANY_OTHER_PROBLEMS_IDENTIFIED,@COMMENTS_LINE_1,@COMMENTS_LINE_2,@COMMENTS_LINE_3,@COMMENTS_LINE_4,@CHW_SIGN,@TL_NAME,@TL_VERIFY_DATE,@F123)";

                    Dapper.SqlMapper.Execute(connection, sql, health);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Health/Edit/5
        public ActionResult Edit(int id)
        {
            Health health;
            using (var connection = AppUtils.GetOpenConnection())
            {
                string sql = "select * from main where Id = @Id";
                health = Dapper.SqlMapper.Query<Health>(connection, sql, new { Id = id }).ToList().First();
            }

            return View(health);
        }

        // POST: Health/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Health health)
        {
            try
            {
                using (var connection = AppUtils.GetOpenConnection())
                {
                    string sql = "update main set OFFICIAL_HOUSE_REG_NO = @OFFICIAL_HOUSE_REG_NO, CHW_ID_NO = @CHW_ID_NO, DATE_OF_VISIT = @DATE_OF_VISIT, CHW_NAME = @CHW_NAME, DISTRICT = @DISTRICT, PROVINCE = @PROVINCE,	WARD_DHIS = @WARD_DHIS,	CLINIC_NAME = @CLINIC_NAME,	TEAM_NAME = @TEAM_NAME,	HOUSEHOLD_HEAD_NAME = @HOUSEHOLD_HEAD_NAME,	HOUSEHOLD_ADDRESS = @HOUSEHOLD_ADDRESS,	HOUSEHOLD_HEAD_TEL = @HOUSEHOLD_HEAD_TEL, HOUSEHOLD_RESPONDENT = @HOUSEHOLD_RESPONDENT, MEMBER_1_NAME = @MEMBER_1_NAME, MEMBER_1_DOB = @MEMBER_1_DOB, MEMBER_1_AGE = @MEMBER_1_AGE, MEMBER_1_GENDER = @MEMBER_1_GENDER,	MEMBER_2_NAME = @MEMBER_2_NAME,	MEMBER_2_AGE = @MEMBER_2_AGE, MEMBER_2_DOB = @MEMBER_2_DOB,	MEMBER_2_GENDER = @MEMBER_2_GENDER,HOUSEHOLD_TOILET = @HOUSEHOLD_TOILET, MEMBER_3_NAME = @MEMBER_3_NAME, MEMBER_3_DOB = @MEMBER_3_DOB,	MEMBER_3_AGE = @MEMBER_3_AGE,MEMBER_3_GENDER = @MEMBER_3_GENDER,	MEMBER_4_NAME = @MEMBER_4_NAME,	MEMBER_4_DOB = @MEMBER_4_DOB, MEMBER_4_AGE = @MEMBER_4_AGE,MEMBER_4_GENDER = @MEMBER_4_GENDER,	MEMBER_5_NAME = @MEMBER_5_NAME,	MEMBER_5_DOB = @MEMBER_5_DOB,MEMBER_5_AGE = @MEMBER_5_AGE,MEMBER_5_GENDER = @MEMBER_5_GENDER,	MEMBER_6_NAME = @MEMBER_6_NAME,	MEMBER_6_DOB = @MEMBER_6_DOB, MEMBER_6_AGE = @MEMBER_6_AGE,MEMBER_6_GENDER = @MEMBER_6_GENDER,	MEMBER_7_NAME = @MEMBER_7_NAME,	MEMBER_7_DOB = @MEMBER_7_DOB, MEMBER_7_AGE = @MEMBER_7_AGE,MEMBER_7_GENDER = @MEMBER_7_GENDER,	MEMBER_8_NAME = @MEMBER_8_NAME,	MEMBER_8_DOB = @MEMBER_8_DOB, MEMBER_8_AGE = @MEMBER_8_AGE,MEMBER_8_GENDER = @MEMBER_8_GENDER,	HOUSEHOLD_NUMBER_OF_PEOPLE = @HOUSEHOLD_NUMBER_OF_PEOPLE,ALL_HOUSEHOLD_MEMBERS_REGISTERED = @ALL_HOUSEHOLD_MEMBERS_REGISTERED, HOUSEHOLD_ELECTRICITY = @HOUSEHOLD_ELECTRICITY,HOUSEHOLD_PUMPED_WATER = @HOUSEHOLD_PUMPED_WATER,	HOUSEHOLD_FRIDGE = @HOUSEHOLD_FRIDGE, HOUSEHOLD_ROOMS = @HOUSEHOLD_ROOMS,HOUSEHOLD_GRANTS = @HOUSEHOLD_GRANTS, HOUSEHOLD_MEMBERS_THAT_WORK = @HOUSEHOLD_MEMBERS_THAT_WORK,LEARNERS_SCHOOLS_1 = @LEARNERS_SCHOOLS_1, LEARNERS_SCHOOLS_2 = @LEARNERS_SCHOOLS_2,	MEMBER_WITH_PERSISTANT_COUGH = @MEMBER_WITH_PERSISTANT_COUGH, MEMBER_WITH_NIGHT_SWEATS = @MEMBER_WITH_NIGHT_SWEATS,MEMBER_WITH_WEIGHT_LOSS = @MEMBER_WITH_WEIGHT_LOSS, MEMBER_WITH_FEVER = @MEMBER_WITH_FEVER,	MEMBER_WITH_LOSS_OF_APPITITE = @MEMBER_WITH_LOSS_OF_APPITITE, MEMBER_WITH_TB_SYMPTOMS = @MEMBER_WITH_TB_SYMPTOMS,MEMBER_NEEDING_HIV_TEST = @MEMBER_NEEDING_HIV_TEST,	MEMBERS_WITH_SOCIAL_GRANTS = @MEMBERS_WITH_SOCIAL_GRANTS,	MEMBERS_APPLYING_FOR_GRANTS = @MEMBERS_APPLYING_FOR_GRANTS, MEMBER_WHO_WOULD_LIKE_HIV_TEST = @MEMBER_WHO_WOULD_LIKE_HIV_TEST,	MEMBER_NEEDING_FAMILY_PLANNING = @MEMBER_NEEDING_FAMILY_PLANNING, MEMBER_WITH_UNMET_FAMILY_PLANNING_NEEDS = @MEMBER_WITH_UNMET_FAMILY_PLANNING_NEEDS,	MEMBER_WHO_NEEDS_HELP_WITH_DAILY_ACTIVITES = @MEMBER_WHO_NEEDS_HELP_WITH_DAILY_ACTIVITES,MEMBER_THAT_NEEDS_ADL_HELP = @MEMBER_THAT_NEEDS_ADL_HELP, HOUSEHOLD_CHILD_HEAD = @HOUSEHOLD_CHILD_HEAD,AGE_OF_HOUSEHOLD_HEAD = @AGE_OF_HOUSEHOLD_HEAD, HOUSEHOLD_PREGNANCY_OR_PERION_IN_6_WEEKS = @HOUSEHOLD_PREGNANCY_OR_PERION_IN_6_WEEKS,MEMBERS_PREGNANT_IN_HOUSEHOLD = @MEMBERS_PREGNANT_IN_HOUSEHOLD,	BABY_DELIVERIES_IN_PAST_6_WEEKS = @BABY_DELIVERIES_IN_PAST_6_WEEKS,NUMBER_OF_BABIES_IN_6_WEEKS = @NUMBER_OF_BABIES_IN_6_WEEKS, HOUSEHOLD_CHILDREN_UNDER_5 = @HOUSEHOLD_CHILDREN_UNDER_5,NUMBER_OF_CHILDREN_UNDER_5_IN_HOUSEHOLD = @NUMBER_OF_CHILDREN_UNDER_5_IN_HOUSEHOLD,	MEMBER_TAKING_MEDICATION = @MEMBER_TAKING_MEDICATION,MEMBER_NUMBER_TAKING_CHRONIC_MEDICATION = @MEMBER_NUMBER_TAKING_CHRONIC_MEDICATION,	NOTE_ON_HOUSEHOLD_SCREENING = @NOTE_ON_HOUSEHOLD_SCREENING,FOLLOW_UP_DATE = @FOLLOW_UP_DATE, PREGNANT_MEMBER_EXPECTED_DATE = @PREGNANT_MEMBER_EXPECTED_DATE,MEMBER_NUMBER_CURRENTLY_PREGNANT = @MEMBER_NUMBER_CURRENTLY_PREGNANT,REFERALLS_ISSUED_FOR_PREGNANT_MEMBER = @REFERALLS_ISSUED_FOR_PREGNANT_MEMBER,DOB_MEMBER_BORN_WITHIN_6_WEEKS = @DOB_MEMBER_BORN_WITHIN_6_WEEKS, MEMBER_NUMBER_BORN_WITHIN_THE_LAST_6_WEEKS = @MEMBER_NUMBER_BORN_WITHIN_THE_LAST_6_WEEKS,BABY_WEIGHT_LESS_THAN_2500G = @BABY_WEIGHT_LESS_THAN_2500G,MEMBER_NUMBER_BIRTH_WEIGHT_LESS_THAN_2500g = @MEMBER_NUMBER_BIRTH_WEIGHT_LESS_THAN_2500g,NUMBER_OF_REFERRALS_FOR_UNDER_WEIGHT_BABIES = @NUMBER_OF_REFERRALS_FOR_UNDER_WEIGHT_BABIES,CHILRDEN_UNDER_5_NOT_IMMUNIZED = @CHILRDEN_UNDER_5_NOT_IMMUNIZED,	CHILDREN_UNDER_5_WITH_NO_VIT_A_IN_6_MONTHS = @CHILDREN_UNDER_5_WITH_NO_VIT_A_IN_6_MONTHS,	REFERRAL_FORMS_ISSUED_BABIES_BORN_WITHIN_6_WEEKS_IF_NECESSARY = @REFERRAL_FORMS_ISSUED_BABIES_BORN_WITHIN_6_WEEKS_IF_NECESSARY,MEMBER_NUMBER_WHOSE_IMMUNIZATION_IS_NOT_UP_TO_DATE = @MEMBER_NUMBER_WHOSE_IMMUNIZATION_IS_NOT_UP_TO_DATE,	REFFERALS_ISSUED_FOR_CHILDREN_NOT_IMMUNIZED = @REFFERALS_ISSUED_FOR_CHILDREN_NOT_IMMUNIZED,MEMBER_NUMBER_NOT_HAD_VITAMIN_A_PROPHYLAXIS = @MEMBER_NUMBER_NOT_HAD_VITAMIN_A_PROPHYLAXIS,	CHILDREN_NOT_WEIGHED_OR_UNDER_WEIGHT = @CHILDREN_NOT_WEIGHED_OR_UNDER_WEIGHT,MEMBER_NUMBER_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION = @MEMBER_NUMBER_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION,	CHILDREN_SUSPECTED_OF_ILLNESS_OR_CONCERNS = @CHILDREN_SUSPECTED_OF_ILLNESS_OR_CONCERNS,	REFERRALS_FOR__VITAMIN_A_PROPHYLAXIS = @REFERRALS_FOR__VITAMIN_A_PROPHYLAXIS,	REFFERALS_FOR_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION = @REFFERALS_FOR_NOT_WEIGHED_SHOWS_SIGNS_OF_MALNUTRITION,	MEMBER_NUMBER_SUSPECTED_OF_ILLNESS_OR_CONCERNS = @MEMBER_NUMBER_SUSPECTED_OF_ILLNESS_OR_CONCERNS,	REFFERALS_FOR_NOT_WEIGHED_CHILDREN_SHOWS_SIGNS_OF_MALNUTRITION = @REFFERALS_FOR_NOT_WEIGHED_CHILDREN_SHOWS_SIGNS_OF_MALNUTRITION,	HIV_EXPOSED_CHILDREN_WITHIN_6_WEEKS = @HIV_EXPOSED_CHILDREN_WITHIN_6_WEEKS,	MEMBER_NUMBER_NOT_HAD_PCR__WHO_IS_6_WEEKS_AND_OLDER_HIV_EXPOSED = @MEMBER_NUMBER_NOT_HAD_PCR__WHO_IS_6_WEEKS_AND_OLDER_HIV_EXPOSED,	REFERRALS_FOR_HIV_EXPOSED_CHILDREN_6_WEEKS_OLDER_NOT__PCR_TEST = @REFERRALS_FOR_HIV_EXPOSED_CHILDREN_6_WEEKS_OLDER_NOT__PCR_TEST,	MEMBERS_TAKING_TB-HIV-BP-DIABETES_MEDS = @MEMBERS_TAKING_TB-HIV-BP-DIABETES_MEDS,MEMBER_NUMBER_TAKING_TB-HIV-BP-DIABETES_MEDS = @MEMBER_NUMBER_TAKING_TB-HIV-BP-DIABETES_MEDS,REFERRALS_FOR_TAKING_TB-HIV-BP-DIABETES_MEDS = @REFERRALS_FOR_TAKING_TB-HIV-BP-DIABETES_MEDS,MEMBER_DEFAULTING_FROM_TREATMENT = @MEMBER_DEFAULTING_FROM_TREATMENT,MEMBER_NUMBER_THAT_DEFAULTED = @MEMBER_NUMBER_THAT_DEFAULTED,	REFERRALS_ISSUED_FOR_DEFAULTING_MEMBER = @REFERRALS_ISSUED_FOR_DEFAULTING_MEMBER, ANY_OTHER_PROBLEMS = @ANY_OTHER_PROBLEMS,MEMBER_NUMBER_WITH_IDENTIFIED_PROBLEMS = @MEMBER_NUMBER_WITH_IDENTIFIED_PROBLEMS,	REFERRAL_FORMS_FOR_ANY_OTHER_PROBLEMS_IDENTIFIED = @REFERRAL_FORMS_FOR_ANY_OTHER_PROBLEMS_IDENTIFIED, COMMENTS_LINE_1 = @COMMENTS_LINE_1,COMMENTS_LINE_2 = @COMMENTS_LINE_2,	COMMENTS_LINE_3 = @COMMENTS_LINE_3, COMMENTS_LINE_4 = @COMMENTS_LINE_4,	CHW_SIGN = @CHW_SIGN, TL_NAME = @TL_NAME, TL_VERIFY_DATE = @TL_VERIFY_DATE, F123 = @F123 Id where Id = @Id";
                    Dapper.SqlMapper.Execute(connection, sql, health);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Health/Delete/5
        public ActionResult Delete(int id)
        {
            Health health;
            using (var connection = AppUtils.GetOpenConnection())
            {
                string sql = "select * from main where Id = @Id";
                health = Dapper.SqlMapper.Query<Health>(connection, sql, new { Id = id }).ToList().First();
            }

            return View(health);
        }

        // POST: Health/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var connection = AppUtils.GetOpenConnection())
                {
                    string sql = "delete from main where Id = @Id";
                    Dapper.SqlMapper.Execute(connection, sql, new { Id = id });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public FileResult GeneratePDF(int id)
        {
            using (var connection = AppUtils.GetOpenConnection())
            {
                string sql = "select * from main where Id = @Id";
                Health health = Dapper.SqlMapper.Query<Health>(connection, sql, new { Id = id }).ToList().First();

                string pdf = new Documents().HouseholdRegistrationForm(health);

                string fileName = System.IO.Path.GetFileName(pdf);
                byte[] file = System.IO.File.ReadAllBytes(pdf);

                return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
        }
    }
}
