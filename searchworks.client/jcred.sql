-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 24, 2021 at 12:32 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jcred`
--

-- --------------------------------------------------------

--
-- Table structure for table `bank_preferences`
--

CREATE TABLE `bank_preferences` (
  `id` int(11) NOT NULL,
  `user_email` varchar(255) DEFAULT NULL,
  `bank` varchar(255) DEFAULT NULL,
  `account_number` varchar(255) DEFAULT NULL,
  `account_type` varchar(255) DEFAULT NULL,
  `account_holder` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank_preferences`
--

INSERT INTO `bank_preferences` (`id`, `user_email`, `bank`, `account_number`, `account_type`, `account_holder`) VALUES
(1, 'ray@gmail.com', 'Standard Bank', '1234567', 'Savings', 'Holang Makhumisane'),
(2, 'dawn@gmail.com', '', '', '', ''),
(3, 'doe@doe.com', 'African Bank', '19182828384', 'current', 'Doe Mortu'),
(4, 'koni@gmail.com', 'Stand V', '000111251455', NULL, 'Koni Sitsula'),
(5, 'vhua@gmail.com', 'standard banek', '522246225', NULL, 'vhua sitsula'),
(6, 'nompfa@gmail.com', 'absa', '022655845', NULL, 'nompfa sitsula'),
(7, 'koni@gmail.com', 'Stand V', '000111251455', NULL, 'Koni Sitsula'),
(8, 'konoi@gmail.com', 'absa', '000111251455', NULL, 'Koni Sitsula'),
(9, 'vhuawe@gmail.com', 'Standard Bank', '15222566', NULL, 'Vhuawelo Sitsula'),
(10, 'vhuawe@gmail.com', 'Standard Bank', '00012585255', NULL, 'Vhuawelo Sitsula'),
(11, 'muofhe@gmail.com', 'ABSA', '77784555', NULL, 'muofhe mundalamo'),
(12, 'vhuyo@gmail.com', 'Standard Bank', '00012585255', NULL, 'Sitsula Vhuyo'),
(13, 'vhuyo@ktopportunities.co.za', 'Standard Bank', '15222566', NULL, 'koni sitsula'),
(14, 'tshisi@gmail.com', 'Standard Bank', '00012585255', NULL, 'Vhuawelo Sitsula'),
(15, 'tshisi@gmail.com', 'Standard Bank', '00012585255', NULL, 'koni sitsula'),
(16, 'koni@gmail.com', 'ABSA', '15222566', NULL, 'tshisikhawe sitsula'),
(17, 'koni@gmail.com', 'Standard Bank', '00012585255', NULL, 'koni sitsula'),
(18, 'koni@gmail.com', 'Standard Bank', '00012585255', NULL, 'tshisikhawe sitsula'),
(19, 'vhuyo@gmail.com', 'Standard Bank', '89995455', NULL, 'koni sitsula');

-- --------------------------------------------------------

--
-- Table structure for table `checks`
--

CREATE TABLE `checks` (
  `id` int(11) NOT NULL,
  `search_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `check_id` int(11) DEFAULT NULL,
  `first_name` varchar(255) DEFAULT NULL,
  `maiden_name` varchar(255) DEFAULT NULL,
  `surname` varchar(255) DEFAULT NULL,
  `IDNum` varchar(255) DEFAULT NULL,
  `passportNum` varchar(255) DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `DOB` date DEFAULT NULL,
  `mobile` int(11) NOT NULL,
  `Num_search` int(11) DEFAULT NULL,
  `reason` varchar(255) DEFAULT NULL,
  `consent_Form` varchar(255) DEFAULT NULL,
  `user_id` int(11) NOT NULL,
  `user_email` varchar(255) NOT NULL,
  `status` varchar(255) DEFAULT 'pending',
  `complete_date` varchar(255) DEFAULT NULL,
  `checks` varchar(255) NOT NULL,
  `results` varchar(255) DEFAULT NULL,
  `summary` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `checks`
--

INSERT INTO `checks` (`id`, `search_date`, `check_id`, `first_name`, `maiden_name`, `surname`, `IDNum`, `passportNum`, `country`, `DOB`, `mobile`, `Num_search`, `reason`, `consent_Form`, `user_id`, `user_email`, `status`, `complete_date`, `checks`, `results`, `summary`) VALUES
(1, '2020-01-31 07:53:45', 29861946, 'Dawn', 'Munesu', 'Chikoki', '123456789', 'asjhjagsdhjas', 'Zim', '2020-01-31', 796844953, 2, 'Check', 'Credit-Card-Report.pdf', 25, 'dawnchikoki@gmail.com', 'pending', NULL, '', NULL, NULL),
(2, '2020-01-31 07:53:45', 167787269, 'Dawn', 'Munesu', 'Chikoki', '123456789', 'asjhjagsdhjas', 'Zim', '2020-01-31', 796844953, 2, 'Check', 'Credit-Card-Report.pdf', 25, 'dawnchikoki@gmail.com', 'pending', NULL, '', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `check_list`
--

CREATE TABLE `check_list` (
  `id` int(11) NOT NULL,
  `checks_id` int(11) DEFAULT NULL,
  `checks` varchar(255) DEFAULT NULL,
  `detail_attached_file_name` varchar(255) DEFAULT NULL,
  `results` varchar(255) DEFAULT NULL,
  `summary` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `check_list`
--

INSERT INTO `check_list` (`id`, `checks_id`, `checks`, `detail_attached_file_name`, `results`, `summary`) VALUES
(155, 406757863, 'Fraud Listing | 65.21', '', NULL, ''),
(156, 406757863, 'Permanent Residency | 81.57', '84848473737', NULL, ''),
(157, 316770556, 'SA Work Permit | 107.53', '4444545443', NULL, ''),
(158, 316770556, 'Permanent Residency | 81.57', '84848473737', NULL, ''),
(159, 865654502, 'Citizenship | 137.47', '', NULL, ''),
(160, 865654502, 'Fraud Listing | 65.21', '', NULL, ''),
(161, 561039308, 'Fraud Listing | 65.21', '', NULL, ''),
(162, 561039308, 'Fraud Listing | 65.21', '', NULL, ''),
(163, 74108631, 'Fraud Listing | 65.21', '', NULL, ''),
(164, 74108631, 'ID Verification | 22.04', '', NULL, ''),
(165, 270038356, 'Fraud Listing | 65.21', '', NULL, ''),
(166, 270038356, 'Fraud Listing | 65.21', '', NULL, ''),
(167, 79703444, 'ID Verification | 22.04', '', NULL, ''),
(168, 79703444, 'Academic Qualification (SA) | 84.40', '', NULL, ''),
(169, 826543264, 'ID Verification | 22.04', '', NULL, ''),
(170, 826543264, 'Academic Qualification (SA) | 84.40', '', NULL, ''),
(171, 420367382, 'ID / Passport Verification | 22.04', '', NULL, ''),
(172, 420367382, 'Vehicle Registration | 440.29', '', NULL, ''),
(173, 2290527, 'ID / Passport Verification | 22.04', '', NULL, ''),
(174, 2290527, 'Vehicle Registration | 440.29', '', NULL, ''),
(175, 463669911, 'ID / Passport Verification | 22.04', '', NULL, ''),
(176, 463669911, 'Vehicle Registration | 440.29', '', NULL, ''),
(177, 415713863, 'ID / Passport Verification | 22.04', '', NULL, ''),
(178, 415713863, 'Vehicle Registration | 440.29', '', NULL, ''),
(179, 691492430, 'ID / Passport Verification | 22.04', '', NULL, ''),
(180, 691492430, 'ID / Passport Verification | 22.04', '', NULL, ''),
(181, 124025210, 'ID / Passport Verification | 22.04', '', NULL, ''),
(182, 124025210, 'ID / Passport Verification | 22.04', '', NULL, ''),
(183, 202414443, 'ID / Passport Verification | 22.04', '', NULL, ''),
(184, 642027401, 'ID / Passport Verification | 22.04', '', NULL, ''),
(185, 689611583, 'ID / Passport Verification | 22.04', '', NULL, ''),
(186, 97410341, 'ID / Passport Verification | 22.04', '', NULL, ''),
(187, 93540827, 'ID / Passport Verification | 22.04', '', NULL, ''),
(188, 414627948, 'ID / Passport Verification | 22.04', '', NULL, ''),
(189, 342972498, 'ID / Passport Verification | 22.04', '', NULL, ''),
(190, 906592160, 'ID / Passport Verification | 22.04', '', NULL, ''),
(191, 682910342, 'ID / Passport Verification | 22.04', '', NULL, ''),
(192, 366586243, 'ID / Passport Verification | 22.04', '', NULL, ''),
(193, 670572737, 'ID / Passport Verification | 22.04', '', NULL, ''),
(194, 762639088, 'ID / Passport Verification | 22.04', '', NULL, ''),
(195, 174757397, 'ID / Passport Verification | 22.04', '', NULL, ''),
(196, 856020366, 'ID / Passport Verification | 22.04', '', NULL, ''),
(197, 452160158, 'ID / Passport Verification | 22.04', '', NULL, ''),
(198, 452160158, 'ID / Passport Verification | 22.04', '', NULL, ''),
(199, 120868504, 'ID / Passport Verification | 22.04', '', NULL, ''),
(200, 120868504, 'ID / Passport Verification | 22.04', '', NULL, ''),
(201, 563803729, 'ID / Passport Verification | 22.04', '', NULL, ''),
(202, 563803729, 'ID / Passport Verification | 22.04', '', NULL, ''),
(203, 814206022, 'ID / Passport Verification | 22.04', '', NULL, ''),
(204, 814206022, 'ID / Passport Verification | 22.04', '', NULL, ''),
(205, 847889675, 'ID / Passport Verification | 22.04', '', NULL, ''),
(206, 462968739, 'ID / Passport Verification | 22.04', '', NULL, ''),
(207, 29861946, 'ID / Passport Verification | 22.04', '', NULL, ''),
(208, 29861946, 'ID / Passport Verification | 22.04', '', NULL, ''),
(209, 167787269, 'ID / Passport Verification | 22.04', '', NULL, ''),
(210, 167787269, 'ID / Passport Verification | 22.04', '', NULL, '');

-- --------------------------------------------------------

--
-- Table structure for table `documents`
--

CREATE TABLE `documents` (
  `id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `document` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `documents`
--

INSERT INTO `documents` (`id`, `email`, `document`) VALUES
(1, 'koni@gmail.com', 'L_assets/documents/Peosa.pdf');

-- --------------------------------------------------------

--
-- Table structure for table `employment_details`
--

CREATE TABLE `employment_details` (
  `id` int(11) NOT NULL,
  `user_email` varchar(255) NOT NULL,
  `status` varchar(255) DEFAULT NULL,
  `employer` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `gross` varchar(255) DEFAULT NULL,
  `nett` varchar(255) DEFAULT NULL,
  `industry` varchar(255) DEFAULT NULL,
  `position` varchar(255) DEFAULT NULL,
  `time` varchar(255) DEFAULT NULL,
  `contact` varchar(255) DEFAULT NULL,
  `frequency` varchar(255) DEFAULT NULL,
  `day` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employment_details`
--

INSERT INTO `employment_details` (`id`, `user_email`, `status`, `employer`, `phone`, `gross`, `nett`, `industry`, `position`, `time`, `contact`, `frequency`, `day`) VALUES
(1, 'ray@gmail.com', 'Employed Full Time', 'KT Opportunities', '0799832548', '10000', '1000', 'IT', 'Developer', '1 year', '011 011 0111', 'Monthly', '31'),
(2, 'dawn@gmail.com', '', '', '0', '0', '0', '0', '0', '0', '0', '0', '0'),
(4, 'doe@doe.com', 'full time', 'Raymond Mortu', '0833832282', '50000', '45000', 'civil engineer', 'manager', '2years', '0110029837', 'monthly', '31'),
(5, 'koni@gmail.com', 'Employed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(6, 'vhua@gmail.com', 'Employed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(7, 'nompfa@gmail.com', 'Employed', NULL, '0729756845', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(8, 'koni@gmail.com', 'Employed', NULL, '0729756845', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(9, 'konoi@gmail.com', 'Employed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(10, 'vhuawe@gmail.com', 'Employeed', NULL, '072659874', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(11, 'vhuawe@gmail.com', 'Employeed', NULL, '0767672963', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(12, 'muofhe@gmail.com', 'Employed', NULL, '072986412', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(13, 'vhuyo@gmail.com', 'Employeed', NULL, '0767672963', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(14, 'vhuyo@ktopportunities.co.za', 'Employed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, 'tshisi@gmail.com', 'Employeed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(16, 'tshisi@gmail.com', 'Employeed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(17, 'koni@gmail.com', 'Employed', NULL, '0767672963', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(18, 'koni@gmail.com', 'Employed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(19, 'koni@gmail.com', 'Employed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(20, 'vhuyo@gmail.com', 'Employeed', NULL, '0729756814', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

CREATE TABLE `logs` (
  `id` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `time` varchar(255) NOT NULL,
  `page` varchar(255) NOT NULL,
  `action` varchar(1000) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `user` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`id`, `date`, `time`, `page`, `action`, `user_id`, `user`) VALUES
(8, '2020/05/20', '3:18:38 PM', 'CIPC Company Records', 'Company Name:KT Opportunities', 6, 'Raymond Mortu'),
(9, '2020/05/20', '3:18:42 PM', 'CIPC Company Records', 'Company Name:KT Opportunities', 6, 'Raymond Mortu'),
(10, '2020/05/30', '3:18:42 PM', 'CIPC Individual Records', 'Name:KT Opportunities', 8, 'Dawn Chikoki'),
(11, '2020/05/10', '3:18:42 PM', 'CIPC Individual Records', 'Name:KT Opportunities', 9, 'Dawn Chikoki'),
(12, '2020/05/21', '8:45:35 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(13, '2020/05/21', '9:01:46 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(14, '2020/05/21', '11:05:20 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(15, '2020/05/22', '11:27:03 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(16, '2020/05/22', '11:37:58 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(17, '2020/06/19', '2:41:15 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(18, '2020/06/19', '2:44:04 PM', 'CIPC Company Records', 'Company Name:KT Opportunities', 6, 'Raymond Mortu'),
(19, '2020/06/19', '2:44:08 PM', 'CIPC Company Records', 'Company Name:KT Opportunities', 6, 'Raymond Mortu'),
(20, '2020/06/19', '2:59:13 PM', 'CSI Personal Records', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(21, '2020/06/19', '3:30:16 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(22, '2020/06/19', '3:30:41 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(23, '2020/06/19', '3:47:43 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(24, '2020/06/19', '4:02:09 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(25, '2020/06/19', '4:03:46 PM', 'CSI Personal Records', 'Name:John; Surname:Chikoki; ID:6601215516187', 6, 'Raymond Mortu'),
(26, '2020/06/19', '4:05:24 PM', 'CSI Personal Records', 'Name:Nikita; Surname:Irebe; ID:9405091325185', 6, 'Raymond Mortu'),
(27, '2020/06/19', '4:06:59 PM', 'CIPC Company Records', 'Company Name:Marketo', 6, 'Raymond Mortu'),
(28, '2020/06/19', '4:07:01 PM', 'CIPC Company Records', 'Company Name:Marketo', 6, 'Raymond Mortu'),
(29, '2020/06/19', '4:09:52 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(30, '2020/06/19', '4:10:08 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(31, '2020/06/19', '4:10:38 PM', 'Combined Credit Report', 'Name:John; Surname: Chikoki; Equiry Reason:32; ID: 660121556187', 6, 'Raymond Mortu'),
(32, '2020/06/19', '4:12:15 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(33, '2020/06/19', '4:13:06 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(34, '2020/06/19', '4:13:24 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(35, '2020/06/19', '4:31:03 PM', 'CSI Personal Records', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(36, '2020/06/19', '4:32:11 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(37, '2020/06/19', '4:32:23 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(38, '2020/07/01', '1:58:01 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(39, '2020/07/06', '11:32:06 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(40, '2020/07/08', '10:15:31 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(41, '2020/07/08', '4:03:11 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(42, '2020/07/08', '4:58:26 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(43, '2020/07/08', '5:15:55 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(44, '2020/07/08', '5:17:58 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(45, '2020/07/08', '5:18:41 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(46, '2020/07/08', '5:19:07 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(47, '2020/07/08', '5:27:13 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(48, '2020/07/08', '5:28:57 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(49, '2020/07/08', '5:31:18 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(50, '2020/07/08', '5:35:32 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(51, '2020/07/08', '5:49:26 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(52, '2020/07/08', '5:51:00 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(53, '2020/07/08', '5:55:45 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(54, '2020/07/08', '5:56:37 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(55, '2020/07/14', '12:43:09 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(56, '2020/07/14', '1:31:57 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(57, '2020/07/14', '1:33:10 PM', 'CSI Person Verification By Name and ID Number', 'Name:Thoriso; Surname:Rangata; ID:9303195109086', 6, 'Raymond Mortu'),
(58, '2020/07/14', '1:39:23 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(59, '2020/07/14', '1:40:10 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(60, '2020/07/14', '3:16:47 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(61, '2020/07/14', '3:27:21 PM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(62, '2020/07/14', '3:28:11 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(63, '2020/07/14', '3:32:38 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(64, '2020/07/14', '3:34:45 PM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(65, '2020/07/14', '3:44:19 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(66, '2020/07/14', '4:00:41 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(67, '2020/07/14', '4:03:15 PM', 'CSI Person Verification By Name', 'Name:Thoriso ; Surname:Rangata', 6, 'Raymond Mortu'),
(68, '2020/07/14', '4:04:24 PM', 'CSI Person Verification By Name', 'Name:Thoriso ; Surname:Rangata', 6, 'Raymond Mortu'),
(69, '2020/07/14', '4:49:46 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(70, '2020/07/14', '4:51:41 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(71, '2020/07/14', '4:56:10 PM', 'CIPC Company Records', 'Company Name:KT)', 6, 'Raymond Mortu'),
(72, '2020/07/15', '10:30:40 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(73, '2020/07/27', '1:10:33 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(74, '2020/07/27', '1:11:29 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(75, '2020/07/27', '1:15:46 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(76, '2020/07/27', '1:16:35 PM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(77, '2020/07/27', '1:35:18 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(78, '2020/07/27', '2:14:38 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(79, '2020/07/27', '2:26:42 PM', 'CSI Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(80, '2020/07/27', '3:00:08 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(81, '2020/07/27', '3:00:29 PM', 'CSI Company Trace By Name', 'Company Name:KTO', 6, 'Raymond Mortu'),
(82, '2020/07/27', '3:20:18 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(83, '2020/07/27', '3:40:56 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(84, '2020/07/27', '3:41:14 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(85, '2020/07/27', '3:44:40 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(86, '2020/07/27', '3:45:07 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(87, '2020/07/27', '3:48:29 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(88, '2020/07/27', '3:49:27 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(89, '2020/07/27', '3:51:27 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(90, '2020/07/27', '3:51:43 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(91, '2020/07/27', '3:57:27 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(92, '2020/07/27', '3:57:42 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(93, '2020/07/27', '3:59:11 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(94, '2020/07/27', '3:59:31 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(95, '2020/07/27', '4:01:48 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(96, '2020/07/27', '4:02:04 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(97, '2020/07/27', '4:04:20 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(98, '2020/07/27', '4:04:37 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(99, '2020/07/27', '4:11:31 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(100, '2020/07/27', '4:13:24 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(101, '2020/07/27', '4:18:00 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(102, '2020/07/27', '4:18:20 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(103, '2020/07/27', '4:21:59 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(104, '2020/07/27', '4:24:04 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(105, '2020/07/27', '4:24:30 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(106, '2020/07/27', '4:34:08 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(107, '2020/07/27', '4:40:58 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(108, '2020/07/27', '4:42:02 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(109, '2020/07/27', '4:47:52 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(110, '2020/07/27', '4:48:57 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(111, '2020/07/27', '4:50:37 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(112, '2020/07/27', '4:51:32 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(113, '2020/07/27', '4:52:26 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(114, '2020/07/27', '4:52:38 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(115, '2020/07/27', '4:53:44 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(116, '2020/07/27', '4:54:58 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(117, '2020/07/27', '4:56:44 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(118, '2020/07/28', '11:32:20 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(119, '2020/07/28', '11:33:52 AM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(120, '2020/07/28', '11:33:59 AM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(121, '2020/07/28', '11:34:49 AM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(122, '2020/08/21', '10:55:40 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(123, '2020/08/21', '10:57:43 AM', 'CSI Company Trace By Name', 'Company Name:KTO', 6, 'Raymond Mortu'),
(124, '2020/08/21', '11:01:11 AM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(125, '2020/08/21', '11:01:59 AM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(126, '2020/08/21', '11:03:56 AM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(127, '2020/08/21', '11:18:44 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(128, '2020/08/21', '11:19:07 AM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(129, '2020/08/21', '11:32:05 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(130, '2020/08/21', '11:32:39 AM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(131, '2020/08/21', '11:33:43 AM', 'CSI Company Trace By Name', 'Company Name:KTO', 6, 'Raymond Mortu'),
(132, '2020/08/21', '11:35:02 AM', 'CSI Company Trace By Name', 'Company Name:KTO', 6, 'Raymond Mortu'),
(133, '2020/08/21', '11:37:12 AM', 'CSI Company Trace By Name', 'Company Name:KTO', 6, 'Raymond Mortu'),
(134, '2020/08/21', '11:37:46 AM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(135, '2020/08/21', '11:38:14 AM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(136, '2020/08/21', '11:47:06 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(137, '2020/08/21', '11:48:22 AM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(138, '2020/08/21', '12:00:14 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(139, '2020/08/21', '12:00:30 PM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(140, '2020/08/21', '12:06:06 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(141, '2020/08/21', '12:06:51 PM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(142, '2020/08/21', '12:17:06 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(143, '2020/08/21', '12:18:17 PM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(144, '2020/08/21', '12:24:03 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(145, '2020/08/21', '12:25:49 PM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(146, '2020/08/21', '12:59:28 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(147, '2020/08/21', '1:01:11 PM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(148, '2020/08/21', '1:16:20 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(149, '2020/08/21', '1:40:05 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(150, '2020/08/21', '1:41:31 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(151, '2020/08/21', '2:30:50 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(152, '2020/08/21', '2:31:37 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(153, '2020/08/21', '2:38:41 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(154, '2020/08/21', '2:39:07 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(155, '2020/08/21', '2:46:01 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(156, '2020/08/21', '2:46:49 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(157, '2020/08/21', '2:48:28 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(158, '2020/08/21', '2:49:46 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(159, '2020/08/21', '2:52:20 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(160, '2020/08/21', '4:59:16 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(161, '2020/08/21', '5:02:27 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(162, '2020/08/21', '5:05:10 PM', 'CIPC Company Records', 'Company Name:KTO', 6, 'Raymond Mortu'),
(163, '2020/08/21', '5:09:09 PM', 'CSI Company Trace By Name', 'Company Name:KTO', 6, 'Raymond Mortu'),
(164, '2020/08/21', '5:09:42 PM', 'CSI Company Trace By CompanyID', 'Company ID:6059075', 6, 'Raymond Mortu'),
(165, '2020/08/21', '5:10:55 PM', 'CSI Company Trace By Registration Number', 'Registration Number:2019/180816/07', 6, 'Raymond Mortu'),
(166, '2020/08/21', '5:14:16 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(167, '2020/08/24', '10:52:21 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(168, '2020/08/24', '10:52:47 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(169, '2020/08/24', '11:26:44 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(170, '2020/08/24', '11:27:24 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(171, '2020/08/24', '11:30:27 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(172, '2020/08/24', '11:30:55 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(173, '2020/08/24', '11:31:52 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(174, '2020/08/24', '11:33:20 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(175, '2020/08/24', '11:42:32 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(176, '2020/08/24', '11:44:11 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(177, '2020/08/24', '3:30:56 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(178, '2020/08/24', '3:31:44 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(179, '2020/08/24', '3:33:59 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(180, '2020/08/24', '3:38:42 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(181, '2020/08/24', '3:39:36 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(182, '2020/08/24', '3:40:26 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(183, '2020/08/24', '3:41:23 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(184, '2020/08/24', '3:42:16 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(185, '2020/08/24', '3:45:00 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(186, '2020/08/24', '3:45:45 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(187, '2020/08/24', '3:46:50 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(188, '2020/08/24', '3:47:58 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(189, '2020/08/24', '4:20:55 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(190, '2020/08/24', '4:22:20 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(191, '2020/08/24', '4:23:58 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(192, '2020/08/24', '4:24:28 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(193, '2020/08/24', '4:29:38 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(194, '2020/08/24', '4:31:35 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(195, '2020/08/24', '4:33:37 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(196, '2020/08/24', '4:34:12 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(197, '2020/08/24', '4:35:05 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(198, '2020/08/24', '4:35:52 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(199, '2020/08/24', '4:36:59 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(200, '2020/08/24', '4:40:31 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(201, '2020/08/24', '4:40:49 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(202, '2020/08/24', '4:42:08 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(203, '2020/08/24', '4:43:45 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(204, '2020/08/24', '4:45:35 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(205, '2020/08/27', '11:16:26 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(206, '2020/08/27', '11:17:30 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(207, '2020/08/27', '11:19:47 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(208, '2020/08/27', '11:20:41 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(209, '2020/08/27', '11:22:04 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(210, '2020/08/27', '11:24:57 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(211, '2020/08/27', '11:26:51 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(212, '2020/08/27', '11:29:40 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(213, '2020/08/27', '11:40:55 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(214, '2020/08/27', '11:43:16 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(215, '2020/08/27', '11:51:04 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(216, '2020/08/27', '11:51:45 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(217, '2020/08/27', '11:59:20 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(218, '2020/08/27', '12:01:52 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(219, '2020/08/27', '2:43:45 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(220, '2020/08/27', '2:44:16 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(221, '2020/08/27', '2:49:17 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(222, '2020/08/27', '2:49:34 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(223, '2020/08/27', '2:53:54 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(224, '2020/08/27', '4:37:08 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(225, '2020/08/27', '4:37:50 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(226, '2020/08/27', '5:24:38 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(227, '2020/08/27', '5:25:29 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(228, '2020/08/27', '5:27:18 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(229, '2020/08/28', '9:08:20 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(230, '2020/08/28', '9:10:23 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(231, '2020/08/28', '9:10:38 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(232, '2020/08/31', '11:54:53 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(233, '2020/08/31', '12:00:39 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:33; ID: 9303195109086', 6, 'Raymond Mortu'),
(234, '2020/08/31', '4:23:14 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(235, '2020/08/31', '4:24:09 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:43; ID: 9303195109086', 6, 'Raymond Mortu'),
(236, '2020/08/31', '4:36:08 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(237, '2020/08/31', '4:38:35 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:43; ID: 9303195109086', 6, 'Raymond Mortu'),
(238, '2020/08/31', '4:42:40 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(239, '2020/08/31', '4:43:17 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(240, '2020/08/31', '4:48:19 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(241, '2020/08/31', '4:52:38 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(242, '2020/08/31', '4:53:30 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(243, '2020/09/01', '12:13:32 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(244, '2020/09/01', '12:14:28 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(245, '2020/09/01', '12:16:50 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(246, '2020/09/01', '12:18:06 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(247, '2020/09/01', '12:21:59 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(248, '2020/09/01', '12:24:41 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(249, '2020/09/01', '12:25:31 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(250, '2020/09/01', '12:29:34 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(251, '2020/09/01', '12:30:04 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(252, '2020/09/01', '12:34:29 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(253, '2020/09/01', '1:29:36 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(254, '2020/09/01', '1:32:17 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(255, '2020/09/01', '1:38:17 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(256, '2020/09/01', '1:44:51 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(257, '2020/09/01', '1:45:30 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(258, '2020/09/01', '1:48:39 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(259, '2020/09/01', '1:51:06 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(260, '2020/09/01', '1:59:09 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(261, '2020/09/01', '2:00:22 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(262, '2020/09/01', '2:05:01 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(263, '2020/09/01', '2:11:35 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(264, '2020/09/01', '2:12:06 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(265, '2020/09/01', '2:17:01 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(266, '2020/09/01', '2:17:45 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(267, '2020/09/01', '2:21:40 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(268, '2020/09/01', '2:25:53 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(269, '2020/09/01', '2:27:00 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(270, '2020/09/21', '12:15:12 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(271, '2020/09/21', '12:30:09 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(272, '2020/10/29', '2:24:06 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(273, '2020/10/29', '2:24:22 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(274, '2020/10/29', '2:33:37 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(275, '2020/10/29', '2:40:36 PM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(276, '2020/11/02', '11:13:58 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(277, '2020/11/02', '11:20:14 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(278, '2020/11/02', '11:40:24 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(279, '2020/11/02', '11:45:14 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(280, '2020/11/02', '11:53:48 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(281, '2020/11/02', '11:58:10 AM', 'CIPC Company Records', 'Company Name:Spar', 6, 'Raymond Mortu'),
(282, '2020/11/02', '12:08:44 PM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(283, '2020/11/03', '10:46:22 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(284, '2020/11/03', '4:12:38 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(285, '2020/11/03', '4:12:40 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(286, '2020/11/04', '2:59:03 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(287, '2020/11/04', '3:21:21 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(288, '2020/11/05', '10:40:49 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(289, '2020/11/05', '10:53:03 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(290, '2020/11/05', '11:54:56 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(291, '2020/11/05', '11:54:56 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(292, '2020/11/05', '11:55:53 AM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(293, '2020/11/06', '12:18:02 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(294, '2020/11/06', '12:18:04 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(295, '2020/11/06', '12:23:26 PM', 'Experian Consumer Profile', 'First Name: Throriso; Surname: Rangata; Enquiry Reason: Credit Assessment; Passport: ; ID: 9303195109086', 6, 'Raymond Mortu'),
(296, '2020/11/06', '1:01:50 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(297, '2020/11/06', '1:15:33 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(298, '2020/11/06', '4:11:53 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(299, '2020/11/06', '4:13:47 PM', 'Experian Consumer Profile', 'First Name: Thoriso; Surname: Rangata; Enquiry Reason: Credit Assessment; Passport: ; ID: 9303195109086', 6, 'Raymond Mortu'),
(300, '2020/11/06', '4:37:48 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(301, '2020/11/06', '4:39:06 PM', 'Experian Consumer Profile', 'First Name: Thoriso; Surname: Rangata; Enquiry Reason: Credit Assessment; Passport: ; ID: 9303195109086', 6, 'Raymond Mortu'),
(302, '2020/11/09', '11:25:24 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(303, '2020/11/09', '11:25:24 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(304, '2020/11/09', '11:27:29 AM', 'TransUnion Consumer Contact Information', 'Surname: Rangata; ID Number: 9303195109086; Enquiry Reason: Fraud, Corruption, or Theft Investigationt', 6, 'Raymond Mortu'),
(305, '2020/11/09', '11:29:27 AM', 'TransUnion Consumer Contact Information', 'Surname: Rangata; ID Number: 9303195109086; Enquiry Reason: Fraud, Corruption, or Theft Investigationt', 6, 'Raymond Mortu'),
(306, '2020/11/09', '11:48:52 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(307, '2020/11/09', '11:50:34 AM', 'TransUnion Consumer ID Verification', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(308, '2020/11/09', '12:03:45 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(309, '2020/11/09', '12:05:13 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(310, '2020/11/09', '12:09:20 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(311, '2020/11/09', '1:14:41 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(312, '2020/11/09', '1:16:42 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(313, '2020/11/09', '1:32:18 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(314, '2020/11/09', '1:33:50 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(315, '2020/11/09', '1:38:43 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(316, '2020/11/09', '1:39:09 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(317, '2020/11/09', '1:42:54 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(318, '2020/11/09', '1:45:05 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(319, '2020/11/09', '1:47:54 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(320, '2020/11/09', '1:48:57 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(321, '2020/11/09', '1:53:16 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(322, '2020/11/09', '1:54:21 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(323, '2020/11/09', '1:58:07 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(324, '2020/11/09', '1:58:39 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(325, '2020/11/09', '2:02:24 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(326, '2020/11/09', '2:02:59 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(327, '2020/11/09', '2:09:34 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(328, '2020/11/09', '2:11:24 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(329, '2020/11/09', '2:14:39 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(330, '2020/11/09', '2:15:22 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(331, '2020/11/09', '2:19:34 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(332, '2020/11/09', '2:20:05 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(333, '2020/11/09', '2:31:21 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(334, '2020/11/09', '2:31:55 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(335, '2020/11/09', '2:34:19 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(336, '2020/11/09', '2:34:41 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(337, '2020/11/09', '2:35:52 PM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(338, '2020/11/09', '2:37:09 PM', 'Experian Consumer Profile', 'First Name: Thoriso; Surname: Rangata; Enquiry Reason: Credit Assessment; Passport: ; ID: 9303195109086', 6, 'Raymond Mortu'),
(339, '2020/11/09', '2:38:32 PM', 'TransUnion Consumer Contact Information', 'Surname: Rangata; ID Number: 9303195109086; Enquiry Reason: Fraud, Corruption, or Theft Investigationt', 6, 'Raymond Mortu'),
(340, '2020/11/09', '2:39:05 PM', 'TransUnion Consumer ID Verification', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(341, '2020/11/09', '2:40:04 PM', 'TransUnion Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(342, '2020/11/10', '10:52:12 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(343, '2020/11/10', '10:55:24 AM', 'VeriCred Consumer Profile', 'ID: 9303195109086; Enquiry Reason: 2', 6, 'Raymond Mortu'),
(344, '2020/11/10', '11:17:26 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(345, '2020/11/10', '11:17:29 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(346, '2020/11/10', '11:17:50 AM', 'VeriCred Contact Info By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(347, '2020/11/10', '11:51:46 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(348, '2020/11/10', '11:55:15 AM', 'VeriCred ID Photo Verification', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(349, '2020/11/10', '12:00:37 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(350, '2020/11/10', '12:00:58 PM', 'VeriCred ID Photo Verification', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(351, '2020/11/10', '1:25:51 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(352, '2020/11/10', '1:29:08 PM', 'VeriCred Income Estimate By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(353, '2020/11/10', '1:33:14 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(354, '2020/11/10', '1:37:09 PM', 'VeriCred Income Estimate By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(355, '2020/11/10', '1:47:33 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(356, '2020/11/10', '1:47:33 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(357, '2020/11/10', '1:50:53 PM', 'CompuScan Employment Confidence Index', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(358, '2020/11/10', '1:59:41 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(359, '2020/11/10', '2:00:31 PM', 'CompuScan Consumer Profile', 'First Name: Thoriso; Surname: Rangata; Enquiry Reason: 19; ID: 9303195109086', 6, 'Raymond Mortu'),
(360, '2020/11/10', '2:04:35 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(361, '2020/11/10', '2:06:14 PM', 'CompuScan Consumer Trace By Telephone Number', 'Telephone Number: 0722717331', 6, 'Raymond Mortu'),
(362, '2020/11/10', '2:10:09 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(363, '2020/11/10', '2:10:33 PM', 'CompuScan Consumer Trace By Telephone Number', 'Telephone Number: 0722717331', 6, 'Raymond Mortu'),
(364, '2020/11/10', '2:12:11 PM', 'CompuScan Consumer Trace By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(365, '2020/11/10', '2:13:21 PM', 'CompuScan Contact Information', 'First Name: Thoriso; Surname: Rangata; Passport: ; ID: 9303195109086', 6, 'Raymond Mortu'),
(366, '2020/11/10', '2:23:30 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(367, '2020/11/10', '2:24:28 PM', 'CompuScan Employment Confidence Index', 'First Name: Thoriso; Surname: Rangata; ID: 9303195109086', 6, 'Raymond Mortu'),
(368, '2020/11/10', '2:25:22 PM', 'CompuScan ID Photo Verification', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(369, '2020/11/10', '2:26:58 PM', 'CompuScan ID Photo Verification', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(370, '2020/11/10', '2:27:57 PM', 'VeriCred Income Estimate By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(371, '2020/11/10', '2:33:49 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(372, '2020/11/10', '2:35:04 PM', 'VeriCred Income Estimate By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(373, '2020/11/10', '2:44:01 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(374, '2020/11/10', '2:44:29 PM', 'VeriCred Income Estimate By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(375, '2020/11/10', '2:55:05 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(376, '2020/11/10', '2:56:16 PM', 'VeriCred Income Estimate By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(377, '2020/11/10', '3:11:35 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(378, '2020/11/10', '3:18:39 PM', 'VeriCred Person Verification By IDNumber', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(379, '2020/11/11', '1:27:39 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(380, '2020/11/11', '2:52:33 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(381, '2020/11/11', '2:53:47 PM', 'XDS Consumer ID Verification', 'Name: Thoriso; Surname: Rangata; ID: 9303195109086', 6, 'Raymond Mortu'),
(382, '2020/11/11', '3:09:56 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(383, '2020/11/11', '3:10:41 PM', 'XDS Consumer ID Verification', 'Name: Thoriso; Surname: Rangata; ID: 9303195109086', 6, 'Raymond Mortu'),
(384, '2020/11/11', '3:19:22 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(385, '2020/11/11', '3:20:43 PM', 'XDS Consumer ID Verification', 'Name: Thoriso; Surname: Rangata; ID: 9303195109086', 6, 'Raymond Mortu'),
(386, '2020/11/11', '3:23:01 PM', 'XDS Consumer ID Verification', 'Name: Thoriso; Surname: Rangata; ID: 9303195109086', 6, 'Raymond Mortu'),
(387, '2020/11/11', '3:25:19 PM', 'XDS Consumer ID Verification', 'Name: Thoriso; Surname: Rangata; ID: 9303195109086', 6, 'Raymond Mortu'),
(388, '2020/11/11', '3:27:44 PM', 'XDS Consumer ID Verification', 'Name: ; Surname: ; ID: 9303195109086', 6, 'Raymond Mortu'),
(389, '2020/11/11', '3:39:03 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(390, '2020/11/11', '3:41:03 PM', 'XDS Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(391, '2020/11/11', '3:48:38 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(392, '2020/11/11', '3:49:20 PM', 'XDS Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(393, '2020/11/11', '4:02:47 PM', 'XDS Consumer Trace By ID Number', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(394, '2020/11/11', '4:06:37 PM', 'XDS Consumer Trace by Name', 'First Name: Thoriso; Surname: Rangata; Date Of Birth: 1993-03-19', 6, 'Raymond Mortu'),
(395, '2020/11/11', '4:13:29 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(396, '2020/11/11', '4:14:23 PM', 'XDS Consumer Trace by Name', 'First Name: Thoriso; Surname: Rangata; Date Of Birth: 1993-03-19', 6, 'Raymond Mortu'),
(397, '2020/11/11', '4:18:54 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(398, '2020/11/11', '4:19:59 PM', 'XDS Consumer Trace by Name', 'First Name: Thoriso; Surname: Rangata; Date Of Birth: 1993-03-19', 6, 'Raymond Mortu'),
(399, '2020/11/11', '4:33:59 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(400, '2020/11/11', '4:38:26 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(401, '2020/11/12', '11:50:21 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(402, '2020/11/12', '11:51:21 AM', 'CIPC Company Records', 'Company Name:Spar', 6, 'Raymond Mortu'),
(403, '2020/11/13', '10:37:58 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(404, '2020/11/13', '10:40:50 AM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rnagata', 6, 'Raymond Mortu'),
(405, '2020/11/13', '11:05:56 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(406, '2020/11/13', '11:06:48 AM', 'CSI Person Verification By Name', 'Name:Thoriso; Surname:Rangata', 6, 'Raymond Mortu'),
(407, '2020/11/13', '11:09:33 AM', 'CSI Company Trace By Name', 'Company Name:Spar', 6, 'Raymond Mortu'),
(408, '2020/11/13', '11:10:08 AM', 'CSI Company Trace By Name', 'Company Name:excellent women in testing ', 6, 'Raymond Mortu'),
(409, '2020/11/13', '11:10:31 AM', 'CSI Company Trace By Name', 'Company Name:EWIT', 6, 'Raymond Mortu'),
(410, '2020/11/13', '11:12:43 AM', 'Combined Consumer Trace', 'ID: 9303195109086', 6, 'Raymond Mortu'),
(411, '2020/11/13', '11:15:14 AM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:32; ID: 9303195109086', 6, 'Raymond Mortu'),
(412, '2020/11/13', '11:17:07 AM', 'Combined Credit Report', 'Name:Thoriso; Surname: Rangata; Equiry Reason:43; ID: 9303195109086', 6, 'Raymond Mortu'),
(413, '2020/11/13', '11:18:13 AM', 'CompuScan Consumer Profile', 'First Name: Thoriso; Surname: Rangata; Enquiry Reason: 1; ID: 9303195109086', 6, 'Raymond Mortu'),
(414, '2020/11/19', '3:37:28 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(415, '2021/02/10', '9:13:49 AM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu'),
(416, '2021/02/10', '9:14:39 AM', 'CIPC Company Records', 'Company Name:Spar', 6, 'Raymond Mortu'),
(417, '2021-03-18', '10:54:18', 'Individual CSI', 'New Individual CSI Search: Surname=;Firstname=;ID#=', 0, 'ray@gmail.com'),
(418, '2021/03/18', '12:02:47 PM', 'Login', 'Email:ray@gmail.com', 6, 'Raymond Mortu');

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `email` varchar(50) NOT NULL,
  `company` varchar(255) NOT NULL,
  `province` varchar(255) NOT NULL,
  `password` varchar(128) NOT NULL DEFAULT '123456',
  `user_type` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`id`, `name`, `surname`, `email`, `company`, `province`, `password`, `user_type`) VALUES
(25, 'Dawn', 'Chikoki', 'dawnchikoki@gmail.com', 'KTO', 'Gauteng', '123456', 'client'),
(23, 'Raymond', 'Mortu', 'raymond.mortu@gmail.com', 'KTO', 'Gauteng', '123456', 'client'),
(20, 'Super', 'SuperAdmin', 'doe.mortu@gmail.com', 'KTO', 'Gauteng', '123456', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `search_history`
--

CREATE TABLE `search_history` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `application_date` datetime NOT NULL DEFAULT current_timestamp(),
  `applicant_Fname` varchar(255) NOT NULL,
  `applicant_Lname` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `id_Number` varchar(255) NOT NULL,
  `account_user` varchar(255) NOT NULL,
  `region` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `search_history`
--

INSERT INTO `search_history` (`id`, `user_id`, `application_date`, `applicant_Fname`, `applicant_Lname`, `status`, `id_Number`, `account_user`, `region`) VALUES
(1, 1, '2019-09-17 23:09:18', 'Doe', 'Mor', 'pending', '93837232733733', 'Raymond', 'Gauteng');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `uid` int(11) NOT NULL,
  `date_added` varchar(255) DEFAULT NULL,
  `fullname` varchar(255) NOT NULL,
  `phone` varchar(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `code` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL DEFAULT 'admin12',
  `type` varchar(255) NOT NULL,
  `org` varchar(255) NOT NULL,
  `avatar` varchar(100) NOT NULL,
  `cover` varchar(100) NOT NULL,
  `logo` varchar(255) NOT NULL,
  `dob` varchar(255) NOT NULL,
  `gender` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`uid`, `date_added`, `fullname`, `phone`, `email`, `address`, `city`, `code`, `password`, `type`, `org`, `avatar`, `cover`, `logo`, `dob`, `gender`) VALUES
(6, '2019-03-14 11:35:39.987965', 'Raymond Mortu', '0799832549', 'ray@gmail.com', 'SBTI building 220 2nd st, Halfway House', 'Midrand', '1685', '12345', 'Super-Super-Admin', 'VHUYO ORG', '', '', '', '', ''),
(7, '2019-03-14 11:35:39.987965', 'Raymond Doe Mortu', '0736532113', 'doe@gmail.com', '383 Willow Crest, Sagewood st, Noordwyk', 'Cape Town', '1686', '123456', 'Admin', 'Legal Hint', 'L_assets/images/avatar/gif1.gif', 'L_assets/images/cover/cool-wallpaper-4.jpg', '', '', ''),
(8, '2019-03-14 11:35:39.987965', 'doe Mortu', '0736532113', 'doe@doe.com', '383 willo rod', 'midrand', '1938', '123456', 'Admin', 'VHUYO ORG', '', '', '', '', ''),
(9, '2019-03-14 11:35:39.987965', 'k Joe', '0728372288', 'joe@gmai.com', '', '', '', '123456', 'investor', 'Legal Hint', '', '', '', '', ''),
(23, '2019-03-14 11:35:39.987965', 'Joe Dre', '0736532113', 'joe@gmail.com', '383 Willow Crest, Sagewood st, Noordwyk', 'Cape Town', '1092', '1844156d4166d94387f1a4ad031ca5fa', 'Super-Super-Admin', '', '', '', '', '', ''),
(40, '2019-03-29 08:31:18.363347', 'tshisikhawe sitsula', '0767672963', 'tshisi@gmail.com', 'P.O.BOX 2794 ', 'SIBASA', '568', 'admin12', 'Super-Admin', 'TSHISI ORGANIZATION', '', '', 'L_assets/images/logos/c3.png', '', ''),
(41, '2019-03-29 11:38:28.060081', 'koni sitsula', '0729756814', 'vhuyo@gmail.com', 'P.O.BOX 2794 ', 'SIBASA', '855', 'admin12', 'Super-Admin', 'VHUYO ORG', '', '', 'L_assets/images/logos/c5.png', '', ''),
(47, '2020/05/06', 'Test', '7236472342', 'test@gmail.com', '', '', '', 'admin12', 'Admin', 'KTO', '', '', '', '2020-05-06', 'Male'),
(59, '2020/06/19', '', '', '', '', '', '', 'admin12', '', '', '', '', '', '', ''),
(60, '2020/06/19', '', '', '', '', '', '', 'admin12', '', '', '', '', '', '', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bank_preferences`
--
ALTER TABLE `bank_preferences`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `checks`
--
ALTER TABLE `checks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `check_list`
--
ALTER TABLE `check_list`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `documents`
--
ALTER TABLE `documents`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employment_details`
--
ALTER TABLE `employment_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `logs`
--
ALTER TABLE `logs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `search_history`
--
ALTER TABLE `search_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`uid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bank_preferences`
--
ALTER TABLE `bank_preferences`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `checks`
--
ALTER TABLE `checks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `check_list`
--
ALTER TABLE `check_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=211;

--
-- AUTO_INCREMENT for table `documents`
--
ALTER TABLE `documents`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `employment_details`
--
ALTER TABLE `employment_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `logs`
--
ALTER TABLE `logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=419;

--
-- AUTO_INCREMENT for table `members`
--
ALTER TABLE `members`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `search_history`
--
ALTER TABLE `search_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `uid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
