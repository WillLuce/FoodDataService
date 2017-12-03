/*
  Source Code File

  This table contains codes indicating the type of data (analytical, calculated,
  assumed zero, and so on) in the Nutrient Data file. To improve the usability
  of the database and to provide values for the FNDDS, NDL staff imputed nutrient
  values for a number of proximate components, total dietary fiber, total sugar,
  and vitamin and mineral values.

  Src_Cd:     2-digit code indicating type of data
  SrcCd_Desc: description of source code that identifies the type of nutrient data
*/
CREATE TABLE Src_Cd (
  Src_Cd      CHAR(2)     NOT NULL,
  SrcCd_Desc  CHAR(60)    NOT NULL,
  CONSTRAINT  SRC_CD_PK   PRIMARY KEY(Src_Cd)
);


/*
  Data Derivation Code Description File

  This table provides information on how the nutrient values were determined.
  The file contains the derivation codes and their descriptions.

  Deriv_Cd:   derivation code
  Deriv_Desc: description of derivation code giving specific information on how the value was determined.
*/
CREATE TABLE Deriv_Cd (
  Deriv_Cd	CHAR(4)		NOT NULL,
  Deriv_Desc	CHAR(120)	NOT NULL,
  CONSTRAINT  DERIV_CD_PK PRIMARY KEY(Deriv_Cd)
);


/*
  Sources of Data File

  This table provides a citation to the DataSrc_ID in the Sources of Data Link file.

  DataSrc_ID:     unique ID identifying the reference/source.
  Authors: 	    list of authors for a journal article or name of sponsoring organization for other documents.
  Title: 		    title of article or name of document, such as a report from a company or trade association.
  Year: 		    year article or document was published.
  Journal: 	    name of the journal in which the article was published.
  Vol_City: 	    volume number for journal articles, books, or reports; city where sponsoring organization is located.
  Issue_State:    issue number for journal article; State where the sponsoring organization is located.
  Start_Page: 	starting page number of article/document.
  End_Page: 	    ending page number of article/document.
*/
CREATE TABLE Data_Src (
  DataSrc_ID 	CHAR(6)		NOT NULL,
  Authors 	CHAR(255),
  Title 		CHAR(255)	NOT NULL,
  Year 		CHAR(4),
  Journal 	CHAR(135),
  Vol_City 	CHAR(16),
  Issue_State CHAR(5),
  Start_Page 	CHAR(5),
  End_Page 	CHAR(5),
  CONSTRAINT DATA_SRC_PK PRIMARY KEY(DataSrc_ID)
);


/*
  Footnote File

  This table contains additional information about the food item, household weight,
  and nutrient value.

  NDB_No:		  5-digit Nutrient Databank number that uniquely identifies a food item
  FootNt_No:	sequence number. If a given footnote applies to more than one nutrient number, the same footnote number is used.
  Footnt_Typ:	type of footnote (D = footnote adding information to the food description; M = footnote adding information to measure
              description; N = footnote providing additional information on a nutrient value. If the Footnt_Typ = N, the Nutr_No will also be filled in.
  Nutr_No:	  unique 3-digit identifier code for a nutrient to which footnote applies.
  Footnt_Txt:	footnote text.
*/
CREATE TABLE Footnote (
  NDB_No		CHAR(5)		NOT NULL,
  FootNt_No	CHAR(4)		NOT NULL,
  Footnt_Typ	CHAR(1)		NOT NULL,
  Nutr_No		CHAR(3),
  Footnt_Txt	CHAR(200)	NOT NULL
);


/*
  LanguaL Factors Description File

  This table is a support file to the LanguaL Factor file and contains
  the descriptions for only those factors used in coding the selected
  food items codes in this release of SR.

  Factor_Code:        the LanguaL factor from the Thesaurus.
  Factor_Description: the description of the LanguaL Factor Code from the thesaurus.
*/
CREATE TABLE Langdesc (
  Factor_Code	            CHAR(5)		NOT NULL,
  Factor_Description	    CHAR(140)	NOT NULL,
  CONSTRAINT LANGDESC_PK  PRIMARY KEY (Factor_Code)
);


/*
  Nutrient Definition File

  This table is a support file to the Nutrient Data file.
  It provides the 3-digit nutrient code, unit of measure, INFOODS
  tagname, and description.

  Nutr_No:    unique 3-digit identifier code for a nutrient.
  Units:		units of measure (mg, g, µg, and so on).
  Tagname:	International Network of Food Data Systems (INFOODS) tagnames.
  NutrDesc:	name of nutrient/food component.
  Num_Dec:	number of decimal places to which a nutrient value is rounded
  SR_Order:
*/
CREATE TABLE Nutr_Def (
  Nutr_No		CHAR(3)			NOT NULL,
  Units		CHAR(7)			NOT NULL,
  Tagname		CHAR(20),
  NutrDesc	CHAR(60)		NOT NULL,
  Num_Dec		DECIMAL(6,0)	NOT NULL,
  SR_Order	DECIMAL(6,0)	NOT NULL,
  CONSTRAINT NUTR_DEF_PK PRIMARY KEY (Nutr_No)
);


/*
  Food Group Description File

  This table is a support file to the Food Description file and contains
  a list of food groups and their descriptions.

  FdGrp_Cd:       4-digit code identifying a food group.
  FdGrp_Desc:	    name of food group
*/
CREATE TABLE Fd_Group (
  FdGrp_Cd	CHAR(4)		NOT NULL,	-- 4-digit code identifying a food group.
  FdGrp_Desc	CHAR(60)	NOT NULL,	-- name of food group
  CONSTRAINT FD_GROUP_PK PRIMARY KEY (FdGrp_Cd)
);


/*
  Food Description File

  This table contains long and short descriptions and food group
  designators for all food items, along with common names, manufacturer
  name, scientific name, percentage and description of refuse, and
  factors used for calculating protein and kilocalories, if applicable.
  Items used in the FNDDS are also identified by value of “Y” in the
  Survey field.

  NDB_No: 	    5-digit Nutrient Databank number that uniquely identifies a food item.
  FdGrp_Cd:	    4-digit code indicating food group to which a food item belongs.
  Long_Desc:	    200-character description of food item.
  Shrt_Desc:	    60-character abbreviated description of food item.
  ComName:		other names commonly used to describe a food, including local or regional names.
  ManufacName:	indicates the company that manufactured the product, when appropriate.
  Survey:		    indicates if the food has a complete nutrient profile including all 65 FNDDS nutrients.
  Ref_desc:	    description of inedible parts of a food item (refuse), such as seeds or bone.
  Refuse:		    percentage of refuse
  SciName:		scientific name of the food item.
  N_Factor:	    factor for converting nitrogen to protein.
  Pro_Factor:	    factor for calculating calories from protein.
  Fat_Factor:	    factor for calculating calories from fat.
  CHO_Factor:	    factor for calculating calories from carbohydrate.
*/
CREATE TABLE Food_Des (
  NDB_No 		CHAR(5) 	NOT NULL,
  FdGrp_Cd	CHAR(4) 	NOT NULL,
  Long_Desc	CHAR(200)	NOT NULL,
  Shrt_Desc	CHAR(60)	NOT NULL,
  ComName		CHAR(100),
  ManufacName	CHAR(65),
  Survey		CHAR(1),
  Ref_desc	CHAR(135),
  Refuse		DECIMAL(2),				
  SciName		CHAR(65),
  N_Factor	DECIMAL(4,2),
  Pro_Factor	DECIMAL(4,2),
  Fat_Factor	DECIMAL(4,2),
  CHO_Factor	DECIMAL(4,2),
  CONSTRAINT FOOD_DES_PK PRIMARY KEY (NDB_No),
  CONSTRAINT FOOD_DES_UK UNIQUE (NDB_No,FdGrp_Cd),
  CONSTRAINT FOOD_DES_FK FOREIGN KEY(FdGrp_Cd) REFERENCES fd_group(FdGrp_Cd)
);


/*
  Nutrient Data File

  This table contains the nutrient values and information about the values,
  including expanded statistical information.

  NDB_No 			5-digit Nutrient Databank number that uniquely identifies a food item.
  Nutr_No:		unique 3-digit identifier code for a nutrient.
  Nutr_Val:		amount in 100 grams, edible portion.
  Num_Data_Pts:	number of data points/analyses used to calculate the nutrient value.
  Std_Error:		standard error of the mean. null, if cannot be calculated. The standard error is also not given, if the number of data points is less than three.
  Src_Cd:			code indicating type of data.
  Deriv_Cd:		data derivation code giving specific information on how value is determined.
  Ref_NDB_No:		NDB number of the item used to calculate a missing value.
  Add_Nutr_Mark:	indicates a vitamin or mineral added for fortification or enrichment.
  Num_Studies:	number of studies.
  Min:			minimum value.
  Max:			maximum value.
  DF:				degrees of freedom.
  Low_EB:			Lower 95 percent error bound.
  Up_EB:			Upper 95 percent error bound.
  Stat_cmt:		Statistical comments (see documentation for definitions)
  AddMod_Date:	indicates when a value was either added to the database or last modified
  CC:				confidence code indicating data quality, based on evaluation (NYI)
*/
CREATE TABLE Nut_Data (
  NDB_No 			CHAR(5) 		NOT NULL,
  Nutr_No			CHAR(3)			NOT NULL,
  Nutr_Val		DECIMAL(10,3)	NOT NULL,
  Num_Data_Pts	DECIMAL(5,0)	NOT NULL,
  Std_Error		DECIMAL(8,3),
  Src_Cd			CHAR(2)			NOT NULL,
  Deriv_Cd		CHAR(4),
  Ref_NDB_No		CHAR(5),
  Add_Nutr_Mark	CHAR(1),
  Num_Studies		DECIMAL(2,0),
  Min				DECIMAL(10,3),
  Max				DECIMAL(10,3),
  DF				DECIMAL(4,0),
  Low_EB			DECIMAL(10,3),
  Up_EB			DECIMAL(10,3),
  Stat_cmt		CHAR(10),
  AddMod_Date		CHAR(10),
  CC				CHAR(1),
  CONSTRAINT NUT_DATA_PK PRIMARY KEY (NDB_No, Nutr_No),
  CONSTRAINT NUT_DATA_NDBNO_FK FOREIGN KEY(NDB_No) REFERENCES food_des(NDB_No),
  CONSTRAINT NUT_DATA_NUTDEF_FK FOREIGN KEY(Nutr_No) REFERENCES nutr_def(Nutr_No)
);


/*
  Weight Table

  This table contains the weight in grams of a number of common measures
  for each food item.

  NDB_No:			5-digit Nutrient Databank number that uniquely identifies a food item
  Seq:			sequence number
  Amount:			unit modifier (e.g. 1 in "1 cup")
  Msre_Desc:		description (e.g. cup, diced, 1" pieces)
  Gm_Wgt:			gram weight
  Num_Data_Pts:	number of data points
  Std_Dev:		standard deviation
*/
CREATE TABLE Weight (
  NDB_No			CHAR(5)			NOT NULL,
  Seq				CHAR(2)			NOT NULL,
  Amount			DECIMAL(8,3)	NOT NULL,
  Msre_Desc		CHAR(84)		NOT NULL,
  Gm_Wgt			DECIMAL(7,1)	NOT NULL,
  Num_Data_Pts	DECIMAL(4,0),
  Std_Dev			DECIMAL(7,3),
  CONSTRAINT WEIGHT_PK PRIMARY KEY(NDB_No,Seq),
  CONSTRAINT WEIGHT_NDBNO_FK FOREIGN KEY(NDB_No) REFERENCES food_des(NDB_No)
);


/*
  LanguaL Factor File

  This table is a support file to the Food Description file and contains
  the factors from the LanguaL Thesaurus used to code a particular food.

  NDB_No:		    5-digit Nutrient Databank number that uniquely identifies a food item.
  Factor_Code:	the LanguaL factor from the Thesaurus.
*/
CREATE TABLE Langual (
  NDB_No		CHAR(5)		NOT NULL,
  Factor_Code	CHAR(5)		NOT NULL,
  CONSTRAINT LANGUAL_PK PRIMARY KEY(NDB_No, Factor_Code),
  CONSTRAINT LANGUAL_FOOD_DES_FK FOREIGN KEY (NDB_No) REFERENCES food_des(NDB_No),
  CONSTRAINT LANGUAL_LANGDESC_FK FOREIGN KEY (Factor_Code) REFERENCES langdesc(Factor_Code)
);


/*
  Sources of Data Link File

  This table is used to link the Nutrient Data file with the Sources of Data table.
  It is needed to resolve the many-to-many relationship between the two tables.

  NDB_No:     5-digit Nutrient Databank number that uniquely identifies a food item.
  Nutr_No:	unique 3-digit identifier code for a nutrient.
  DataSrc_ID:	unique ID identifying the reference/source.
*/
CREATE TABLE Dat_Src_Lnk (
  NDB_No 		CHAR(5) 	NOT NULL,
  Nutr_No		CHAR(3)		NOT NULL,
  DataSrc_ID	CHAR(6)		NOT NULL,
  CONSTRAINT DATSRCLN_PK PRIMARY KEY(NDB_No,Nutr_No,DataSrc_ID),
  CONSTRAINT DATSRCLN_NDB_FK FOREIGN KEY(NDB_No) REFERENCES food_des(NDB_No),
  CONSTRAINT DATSRCLN_NUT_FK FOREIGN KEY(Nutr_No) REFERENCES nutr_def(Nutr_No),
  CONSTRAINT DATSRCLN_SRC_FK FOREIGN KEY(DataSrc_ID) REFERENCES data_src(DataSrc_ID)
);
