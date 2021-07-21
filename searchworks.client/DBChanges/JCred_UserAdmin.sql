alter table searchhistory
add column orgtenantid int;

alter table compuscansearchhist
add column orgtenantid int;

alter table transunionsearchHistory
add column orgtenantid int;

alter table xdssearchHistory
add column orgtenantid int;

alter table vericredsearchHistory
add column orgtenantid int;

alter table personinformation
add column orgtenantid int;

alter table contactinformation
add column orgtenantid int;

alter table homeaffairsinformation
add column orgtenantid int;

alter table creditinformation
add column orgtenantid int;

alter table fraudindicatorsummary
add column orgtenantid int;

alter table creditdeclinereason
add column orgtenantid int; 

alter table datacounts
add column orgtenantid int;

alter table debtreviewstatus
add column orgtenantid int;

alter table consumerstatistics
add column orgtenantid int;

alter table nlrstats
add column orgtenantid int;

alter table ccastats
add column orgtenantid int;

alter table nlr12months
add column orgtenantid int;

alter table nlr24months
add column orgtenantid int;

alter table nlr36months
add column orgtenantid int;

alter table cca12months
add column orgtenantid int;

alter table cca24months
add column orgtenantid int;

alter table cca36months
add column orgtenantid int;

alter table enquiryhistory
add column orgtenantid int;

alter table cpa_accounts
add column orgtenantid int;

alter table generalinformation
add column orgtenantid int;

alter table transferInformation
add column orgtenantid int;

alter table erfInformation
add column orgtenantid int;

alter table farminformation
add column orgtenantid int;

alter table nlr_accounts
add column orgtenantid int;

alter table addresshistory
add column orgtenantid int;

alter table telephonehistory
add column orgtenantid int;

alter table employmenthistory
add column orgtenantid int;

alter table directorships
add column orgtenantid int;


alter table logs
add column orgtenantid int,
add column orgtenantname varchar(200); #just in case they rename the company name



CREATE TABLE applog (
  Id int(10) unsigned NOT NULL AUTO_INCREMENT,
  Application varchar(50) DEFAULT NULL,
  Logged datetime DEFAULT NULL,
  Level varchar(50) DEFAULT NULL,
  Message varchar(512) DEFAULT NULL,
  Logger varchar(250) DEFAULT NULL,
  Callsite varchar(512) DEFAULT NULL,
  Exception varchar(512) DEFAULT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


# class OrgCategory --PublicSector, Banking, SOE...etc.

alter table aspnetusers
add column created_at datetime default CURRENT_TIMESTAMP();

alter table aspnetusers
add column passwordcreated_at  datetime default CURRENT_TIMESTAMP();

create table aspnetpasshashhistory
(Id int  AUTO_INCREMENT PRIMARY KEY,
 aspnetuserId varchar(128) not null,
 PasswordHash varchar(1000) not null,
 passwordcreated_at datetime not null,
 passwordexpire_at datetime not null,
 password_valid_days int default 120 not null
 )  ENGINE=InnoDB DEFAULT CHARSET=utf8;
 
 

create table searchtype
(
searchtypeid int  AUTO_INCREMENT PRIMARY KEY,
searchtypename varchar(200),
searchtypecode varchar(10),

 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
)
 ENGINE=InnoDB DEFAULT CHARSET=utf8;

create table searchresulttype
(
searchresulttypeid int  AUTO_INCREMENT PRIMARY KEY,
searchresulttypename varchar(200),
searchresulttypecode varchar(10),

 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
)
 ENGINE=InnoDB DEFAULT CHARSET=utf8;
 
 
create table searchresultstatus
(
searchresultstatusid int  AUTO_INCREMENT PRIMARY KEY,
searchresultstatusname varchar(200),
searchresultstatuscode varchar(10),

 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
)
 ENGINE=InnoDB DEFAULT CHARSET=utf8;





create table searchhistory
(searchhistoryid int  AUTO_INCREMENT PRIMARY KEY,
 searchtypeid int,
 searchdescription varchar(200),
 searchresulttypeid int,
 searchresultstatusid int, 
 
 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



drop table orgcategory;
create table orgcategory
(orgcategoryid int  AUTO_INCREMENT PRIMARY KEY,
 orgcategoryname varchar(200),
 orgcategorycode varchar(20),
 
 
 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# class  Country
drop table  country;

create table country
(
countryid int(11) unsigned  AUTO_INCREMENT PRIMARY KEY,
country_name varchar(200),
country_code varchar(20),

created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `country` WRITE;

--
-- Dumping data for table `apps_countries`
--

INSERT INTO `country` (`countryid`, `country_code`, `country_name`, `created_at`,`updated_at`,`deleted`)
VALUES
  (null, 'AF', 'Afghanistan', sysdate(),sysdate(),0),
  (null, 'AL', 'Albania', sysdate(),sysdate(),0),
  (null, 'DZ', 'Algeria', sysdate(),sysdate(),0),
  (null, 'DS', 'American Samoa', sysdate(),sysdate(),0),
  (null, 'AD', 'Andorra', sysdate(),sysdate(),0),
  (null, 'AO', 'Angola', sysdate(),sysdate(),0),
  (null, 'AI', 'Anguilla', sysdate(),sysdate(),0),
  (null, 'AQ', 'Antarctica', sysdate(),sysdate(),0),
  (null, 'AG', 'Antigua and Barbuda', sysdate(),sysdate(),0),
  (null, 'AR', 'Argentina', sysdate(),sysdate(),0),
  (null, 'AM', 'Armenia', sysdate(),sysdate(),0),
  (null, 'AW', 'Aruba', sysdate(),sysdate(),0),
  (null, 'AU', 'Australia', sysdate(),sysdate(),0),
  (null, 'AT', 'Austria', sysdate(),sysdate(),0),
  (null, 'AZ', 'Azerbaijan', sysdate(),sysdate(),0),
  (null, 'BS', 'Bahamas', sysdate(),sysdate(),0),
  (null, 'BH', 'Bahrain', sysdate(),sysdate(),0),
  (null, 'BD', 'Bangladesh', sysdate(),sysdate(),0),
  (null, 'BB', 'Barbados', sysdate(),sysdate(),0),
  (null, 'BY', 'Belarus', sysdate(),sysdate(),0),
  (null, 'BE', 'Belgium', sysdate(),sysdate(),0),
  (null, 'BZ', 'Belize', sysdate(),sysdate(),0),
  (null, 'BJ', 'Benin', sysdate(),sysdate(),0),
  (null, 'BM', 'Bermuda', sysdate(),sysdate(),0),
  (null, 'BT', 'Bhutan', sysdate(),sysdate(),0),
  (null, 'BO', 'Bolivia', sysdate(),sysdate(),0),
  (null, 'BA', 'Bosnia and Herzegovina', sysdate(),sysdate(),0),
  (null, 'BW', 'Botswana', sysdate(),sysdate(),0),
  (null, 'BV', 'Bouvet Island', sysdate(),sysdate(),0),
  (null, 'BR', 'Brazil', sysdate(),sysdate(),0),
  (null, 'IO', 'British Indian Ocean Territory', sysdate(),sysdate(),0),
  (null, 'BN', 'Brunei Darussalam', sysdate(),sysdate(),0),
  (null, 'BG', 'Bulgaria', sysdate(),sysdate(),0),
  (null, 'BF', 'Burkina Faso', sysdate(),sysdate(),0),
  (null, 'BI', 'Burundi', sysdate(),sysdate(),0),
  (null, 'KH', 'Cambodia', sysdate(),sysdate(),0),
  (null, 'CM', 'Cameroon', sysdate(),sysdate(),0),
  (null, 'CA', 'Canada', sysdate(),sysdate(),0),
  (null, 'CV', 'Cape Verde', sysdate(),sysdate(),0),
  (null, 'KY', 'Cayman Islands', sysdate(),sysdate(),0),
  (null, 'CF', 'Central African Republic', sysdate(),sysdate(),0),
  (null, 'TD', 'Chad', sysdate(),sysdate(),0),
  (null, 'CL', 'Chile', sysdate(),sysdate(),0),
  (null, 'CN', 'China', sysdate(),sysdate(),0),
  (null, 'CX', 'Christmas Island', sysdate(),sysdate(),0),
  (null, 'CC', 'Cocos (Keeling) Islands', sysdate(),sysdate(),0),
  (null, 'CO', 'Colombia', sysdate(),sysdate(),0),
  (null, 'KM', 'Comoros', sysdate(),sysdate(),0),
  (null, 'CD', 'Democratic Republic of the Congo', sysdate(),sysdate(),0),
  (null, 'CG', 'Republic of the Congo', sysdate(),sysdate(),0),
  (null, 'CK', 'Cook Islands', sysdate(),sysdate(),0),
  (null, 'CR', 'Costa Rica', sysdate(),sysdate(),0),
  (null, 'HR', 'Croatia (Hrvatska)', sysdate(),sysdate(),0),
  (null, 'CU', 'Cuba', sysdate(),sysdate(),0),
  (null, 'CY', 'Cyprus', sysdate(),sysdate(),0),
  (null, 'CZ', 'Czech Republic', sysdate(),sysdate(),0),
  (null, 'DK', 'Denmark', sysdate(),sysdate(),0),
  (null, 'DJ', 'Djibouti', sysdate(),sysdate(),0),
  (null, 'DM', 'Dominica', sysdate(),sysdate(),0),
  (null, 'DO', 'Dominican Republic', sysdate(),sysdate(),0),
  (null, 'TP', 'East Timor', sysdate(),sysdate(),0),
  (null, 'EC', 'Ecuador', sysdate(),sysdate(),0),
  (null, 'EG', 'Egypt', sysdate(),sysdate(),0),
  (null, 'SV', 'El Salvador', sysdate(),sysdate(),0),
  (null, 'GQ', 'Equatorial Guinea', sysdate(),sysdate(),0),
  (null, 'ER', 'Eritrea', sysdate(),sysdate(),0),
  (null, 'EE', 'Estonia', sysdate(),sysdate(),0),
  (null, 'ET', 'Ethiopia', sysdate(),sysdate(),0),
  (null, 'FK', 'Falkland Islands (Malvinas)', sysdate(),sysdate(),0),
  (null, 'FO', 'Faroe Islands', sysdate(),sysdate(),0),
  (null, 'FJ', 'Fiji', sysdate(),sysdate(),0),
  (null, 'FI', 'Finland', sysdate(),sysdate(),0),
  (null, 'FR', 'France', sysdate(),sysdate(),0),
  (null, 'FX', 'France, Metropolitan', sysdate(),sysdate(),0),
  (null, 'GF', 'French Guiana', sysdate(),sysdate(),0),
  (null, 'PF', 'French Polynesia', sysdate(),sysdate(),0),
  (null, 'TF', 'French Southern Territories', sysdate(),sysdate(),0),
  (null, 'GA', 'Gabon', sysdate(),sysdate(),0),
  (null, 'GM', 'Gambia', sysdate(),sysdate(),0),
  (null, 'GE', 'Georgia', sysdate(),sysdate(),0),
  (null, 'DE', 'Germany', sysdate(),sysdate(),0),
  (null, 'GH', 'Ghana', sysdate(),sysdate(),0),
  (null, 'GI', 'Gibraltar', sysdate(),sysdate(),0),
  (null, 'GK', 'Guernsey', sysdate(),sysdate(),0),
  (null, 'GR', 'Greece', sysdate(),sysdate(),0),
  (null, 'GL', 'Greenland', sysdate(),sysdate(),0),
  (null, 'GD', 'Grenada', sysdate(),sysdate(),0),
  (null, 'GP', 'Guadeloupe', sysdate(),sysdate(),0),
  (null, 'GU', 'Guam', sysdate(),sysdate(),0),
  (null, 'GT', 'Guatemala', sysdate(),sysdate(),0),
  (null, 'GN', 'Guinea', sysdate(),sysdate(),0),
  (null, 'GW', 'Guinea-Bissau', sysdate(),sysdate(),0),
  (null, 'GY', 'Guyana', sysdate(),sysdate(),0),
  (null, 'HT', 'Haiti', sysdate(),sysdate(),0),
  (null, 'HM', 'Heard and Mc Donald Islands', sysdate(),sysdate(),0),
  (null, 'HN', 'Honduras', sysdate(),sysdate(),0),
  (null, 'HK', 'Hong Kong', sysdate(),sysdate(),0),
  (null, 'HU', 'Hungary', sysdate(),sysdate(),0),
  (null, 'IS', 'Iceland', sysdate(),sysdate(),0),
  (null, 'IN', 'India', sysdate(),sysdate(),0),
  (null, 'IM', 'Isle of Man', sysdate(),sysdate(),0),
  (null, 'ID', 'Indonesia', sysdate(),sysdate(),0),
  (null, 'IR', 'Iran (Islamic Republic of)', sysdate(),sysdate(),0),
  (null, 'IQ', 'Iraq', sysdate(),sysdate(),0),
  (null, 'IE', 'Ireland', sysdate(),sysdate(),0),
  (null, 'IL', 'Israel', sysdate(),sysdate(),0),
  (null, 'IT', 'Italy', sysdate(),sysdate(),0),
  (null, 'CI', 'Ivory Coast', sysdate(),sysdate(),0),
  (null, 'JE', 'Jersey', sysdate(),sysdate(),0),
  (null, 'JM', 'Jamaica', sysdate(),sysdate(),0),
  (null, 'JP', 'Japan', sysdate(),sysdate(),0),
  (null, 'JO', 'Jordan', sysdate(),sysdate(),0),
  (null, 'KZ', 'Kazakhstan', sysdate(),sysdate(),0),
  (null, 'KE', 'Kenya', sysdate(),sysdate(),0),
  (null, 'KI', 'Kiribati', sysdate(),sysdate(),0),
  (null, 'KP', 'Korea, Democratic People''s Republic of', sysdate(),sysdate(),0),
  (null, 'KR', 'Korea, Republic of', sysdate(),sysdate(),0),
  (null, 'XK', 'Kosovo', sysdate(),sysdate(),0),
  (null, 'KW', 'Kuwait', sysdate(),sysdate(),0),
  (null, 'KG', 'Kyrgyzstan', sysdate(),sysdate(),0),
  (null, 'LA', 'Lao People''s Democratic Republic', sysdate(),sysdate(),0),
  (null, 'LV', 'Latvia', sysdate(),sysdate(),0),
  (null, 'LB', 'Lebanon', sysdate(),sysdate(),0),
  (null, 'LS', 'Lesotho', sysdate(),sysdate(),0),
  (null, 'LR', 'Liberia', sysdate(),sysdate(),0),
  (null, 'LY', 'Libyan Arab Jamahiriya', sysdate(),sysdate(),0),
  (null, 'LI', 'Liechtenstein', sysdate(),sysdate(),0),
  (null, 'LT', 'Lithuania', sysdate(),sysdate(),0),
  (null, 'LU', 'Luxembourg', sysdate(),sysdate(),0),
  (null, 'MO', 'Macau', sysdate(),sysdate(),0),
  (null, 'MK', 'North Macedonia', sysdate(),sysdate(),0),
  (null, 'MG', 'Madagascar', sysdate(),sysdate(),0),
  (null, 'MW', 'Malawi', sysdate(),sysdate(),0),
  (null, 'MY', 'Malaysia', sysdate(),sysdate(),0),
  (null, 'MV', 'Maldives', sysdate(),sysdate(),0),
  (null, 'ML', 'Mali', sysdate(),sysdate(),0),
  (null, 'MT', 'Malta', sysdate(),sysdate(),0),
  (null, 'MH', 'Marshall Islands', sysdate(),sysdate(),0),
  (null, 'MQ', 'Martinique', sysdate(),sysdate(),0),
  (null, 'MR', 'Mauritania', sysdate(),sysdate(),0),
  (null, 'MU', 'Mauritius', sysdate(),sysdate(),0),
  (null, 'TY', 'Mayotte', sysdate(),sysdate(),0),
  (null, 'MX', 'Mexico', sysdate(),sysdate(),0),
  (null, 'FM', 'Micronesia, Federated States of', sysdate(),sysdate(),0),
  (null, 'MD', 'Moldova, Republic of', sysdate(),sysdate(),0),
  (null, 'MC', 'Monaco', sysdate(),sysdate(),0),
  (null, 'MN', 'Mongolia', sysdate(),sysdate(),0),
  (null, 'ME', 'Montenegro', sysdate(),sysdate(),0),
  (null, 'MS', 'Montserrat', sysdate(),sysdate(),0),
  (null, 'MA', 'Morocco', sysdate(),sysdate(),0),
  (null, 'MZ', 'Mozambique', sysdate(),sysdate(),0),
  (null, 'MM', 'Myanmar', sysdate(),sysdate(),0),
  (null, 'NA', 'Namibia', sysdate(),sysdate(),0),
  (null, 'NR', 'Nauru', sysdate(),sysdate(),0),
  (null, 'NP', 'Nepal', sysdate(),sysdate(),0),
  (null, 'NL', 'Netherlands', sysdate(),sysdate(),0),
  (null, 'AN', 'Netherlands Antilles', sysdate(),sysdate(),0),
  (null, 'NC', 'New Caledonia', sysdate(),sysdate(),0),
  (null, 'NZ', 'New Zealand', sysdate(),sysdate(),0),
  (null, 'NI', 'Nicaragua', sysdate(),sysdate(),0),
  (null, 'NE', 'Niger', sysdate(),sysdate(),0),
  (null, 'NG', 'Nigeria', sysdate(),sysdate(),0),
  (null, 'NU', 'Niue', sysdate(),sysdate(),0),
  (null, 'NF', 'Norfolk Island', sysdate(),sysdate(),0),
  (null, 'MP', 'Northern Mariana Islands', sysdate(),sysdate(),0),
  (null, 'NO', 'Norway', sysdate(),sysdate(),0),
  (null, 'OM', 'Oman', sysdate(),sysdate(),0),
  (null, 'PK', 'Pakistan', sysdate(),sysdate(),0),
  (null, 'PW', 'Palau', sysdate(),sysdate(),0),
  (null, 'PS', 'Palestine', sysdate(),sysdate(),0),
  (null, 'PA', 'Panama', sysdate(),sysdate(),0),
  (null, 'PG', 'Papua New Guinea', sysdate(),sysdate(),0),
  (null, 'PY', 'Paraguay', sysdate(),sysdate(),0),
  (null, 'PE', 'Peru', sysdate(),sysdate(),0),
  (null, 'PH', 'Philippines', sysdate(),sysdate(),0),
  (null, 'PN', 'Pitcairn', sysdate(),sysdate(),0),
  (null, 'PL', 'Poland', sysdate(),sysdate(),0),
  (null, 'PT', 'Portugal', sysdate(),sysdate(),0),
  (null, 'PR', 'Puerto Rico', sysdate(),sysdate(),0),
  (null, 'QA', 'Qatar', sysdate(),sysdate(),0),
  (null, 'RE', 'Reunion', sysdate(),sysdate(),0),
  (null, 'RO', 'Romania', sysdate(),sysdate(),0),
  (null, 'RU', 'Russian Federation', sysdate(),sysdate(),0),
  (null, 'RW', 'Rwanda', sysdate(),sysdate(),0),
  (null, 'KN', 'Saint Kitts and Nevis', sysdate(),sysdate(),0),
  (null, 'LC', 'Saint Lucia', sysdate(),sysdate(),0),
  (null, 'VC', 'Saint Vincent and the Grenadines', sysdate(),sysdate(),0),
  (null, 'WS', 'Samoa', sysdate(),sysdate(),0),
  (null, 'SM', 'San Marino', sysdate(),sysdate(),0),
  (null, 'ST', 'Sao Tome and Principe', sysdate(),sysdate(),0),
  (null, 'SA', 'Saudi Arabia', sysdate(),sysdate(),0),
  (null, 'SN', 'Senegal', sysdate(),sysdate(),0),
  (null, 'RS', 'Serbia', sysdate(),sysdate(),0),
  (null, 'SC', 'Seychelles', sysdate(),sysdate(),0),
  (null, 'SL', 'Sierra Leone', sysdate(),sysdate(),0),
  (null, 'SG', 'Singapore', sysdate(),sysdate(),0),
  (null, 'SK', 'Slovakia', sysdate(),sysdate(),0),
  (null, 'SI', 'Slovenia', sysdate(),sysdate(),0),
  (null, 'SB', 'Solomon Islands', sysdate(),sysdate(),0),
  (null, 'SO', 'Somalia', sysdate(),sysdate(),0),
  (null, 'ZA', 'South Africa', sysdate(),sysdate(),0),
  (null, 'GS', 'South Georgia South Sandwich Islands', sysdate(),sysdate(),0),
  (null, 'SS', 'South Sudan', sysdate(),sysdate(),0),						    
  (null, 'ES', 'Spain', sysdate(),sysdate(),0),
  (null, 'LK', 'Sri Lanka', sysdate(),sysdate(),0),
  (null, 'SH', 'St. Helena', sysdate(),sysdate(),0),
  (null, 'PM', 'St. Pierre and Miquelon', sysdate(),sysdate(),0),
  (null, 'SD', 'Sudan', sysdate(),sysdate(),0),
  (null, 'SR', 'Suriname', sysdate(),sysdate(),0),
  (null, 'SJ', 'Svalbard and Jan Mayen Islands', sysdate(),sysdate(),0),
  (null, 'SZ', 'Swaziland', sysdate(),sysdate(),0),
  (null, 'SE', 'Sweden', sysdate(),sysdate(),0),
  (null, 'CH', 'Switzerland', sysdate(),sysdate(),0),
  (null, 'SY', 'Syrian Arab Republic', sysdate(),sysdate(),0),
  (null, 'TW', 'Taiwan', sysdate(),sysdate(),0),
  (null, 'TJ', 'Tajikistan', sysdate(),sysdate(),0),
  (null, 'TZ', 'Tanzania, United Republic of', sysdate(),sysdate(),0),
  (null, 'TH', 'Thailand', sysdate(),sysdate(),0),
  (null, 'TG', 'Togo', sysdate(),sysdate(),0),
  (null, 'TK', 'Tokelau', sysdate(),sysdate(),0),
  (null, 'TO', 'Tonga', sysdate(),sysdate(),0),
  (null, 'TT', 'Trinidad and Tobago', sysdate(),sysdate(),0),
  (null, 'TN', 'Tunisia', sysdate(),sysdate(),0),
  (null, 'TR', 'Turkey', sysdate(),sysdate(),0),
  (null, 'TM', 'Turkmenistan', sysdate(),sysdate(),0),
  (null, 'TC', 'Turks and Caicos Islands', sysdate(),sysdate(),0),
  (null, 'TV', 'Tuvalu', sysdate(),sysdate(),0),
  (null, 'UG', 'Uganda', sysdate(),sysdate(),0),
  (null, 'UA', 'Ukraine', sysdate(),sysdate(),0),
  (null, 'AE', 'United Arab Emirates', sysdate(),sysdate(),0),
  (null, 'GB', 'United Kingdom', sysdate(),sysdate(),0),
  (null, 'US', 'United States', sysdate(),sysdate(),0),
  (null, 'UM', 'United States minor outlying islands', sysdate(),sysdate(),0),
  (null, 'UY', 'Uruguay', sysdate(),sysdate(),0),
  (null, 'UZ', 'Uzbekistan', sysdate(),sysdate(),0),
  (null, 'VU', 'Vanuatu', sysdate(),sysdate(),0),
  (null, 'VA', 'Vatican City State', sysdate(),sysdate(),0),
  (null, 'VE', 'Venezuela', sysdate(),sysdate(),0),
  (null, 'VN', 'Vietnam', sysdate(),sysdate(),0),
  (null, 'VG', 'Virgin Islands (British)', sysdate(),sysdate(),0),
  (null, 'VI', 'Virgin Islands (U.S.)', sysdate(),sysdate(),0),
  (null, 'WF', 'Wallis and Futuna Islands', sysdate(),sysdate(),0),
  (null, 'EH', 'Western Sahara', sysdate(),sysdate(),0),
  (null, 'YE', 'Yemen', sysdate(),sysdate(),0),
  (null, 'ZM', 'Zambia', sysdate(),sysdate(),0),
  (null, 'ZW', 'Zimbabwe', sysdate(),sysdate(),0);
UNLOCK TABLES;

# class  OrgRegion
drop table region;
create table orgregion
(
orgregionid int AUTO_INCREMENT PRIMARY KEY,
regionname varchar(200),
regioncode varchar(20),
countryid int,

 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# class OrgTenant , KTO clients
create table orgtenant 
(
 orgtenantid int  AUTO_INCREMENT PRIMARY KEY,
 parent_orgtenantid int,
 orgname varchar(200),
 orgcode varchar(20),
 orgcategoryid int,
 org_regno varchar(20),
 org_vatno varchar(20),

 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;






# class OrgUnit
create table orgunit
(orgunitid int  AUTO_INCREMENT PRIMARY KEY,
 parent_orgunitid int,
 orgtenantid int,
 orgunitname varchar(200),
 orgunitcode varchar(20),
 regionid int, /* # default to national region */

 telephone varchar(20),
 fax varchar(20),
 postal_address varchar(1000),
 postal_code varchar(20),

 physical_address varchar(1000),
 physical_code varchar(20),

 isbillable boolean default true, # default yes

 billing_orgname varchar(20),
 billing_address varchar(1000),
 billing_code varchar(20),
 
 orgunit_regno varchar(20),
 orgunit_vatno varchar(20),


created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


#system priviledges, data driven access control
# class  SysPriv
create table syspriv
(sysprivid int AUTO_INCREMENT PRIMARY KEY,
 sysprivname varchar(200),
 sysprivcode varchar(10),
 
 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



#configured by internal admin
# public class OrgTenantPriv
create table orgtenantpriv
(orgtenantprivid int NOT NULL AUTO_INCREMENT PRIMARY KEY,
 orgtenantid int, 
 sysprivid int,
 
 acl_search boolean,
 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# public class  OrgUnitPrivMap
create table orgunitprivmap
(orgunitprivmapid int  AUTO_INCREMENT PRIMARY KEY,
 orgunitid int, 
 sysprivid int,
 
 acl_search boolean,
 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# public class  OrgUnitUserPrivMap
create table orgunituserprivmap
(orgunitprivmapid int  AUTO_INCREMENT PRIMARY KEY,
 aspiden_uid varchar(256), #identity userid 
 orgunitid int, 
 sysprivid int,
 acl_search boolean,

 created_at datetime,
 updated_at datetime,
 deleted boolean,
 deleted_at datetime
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
