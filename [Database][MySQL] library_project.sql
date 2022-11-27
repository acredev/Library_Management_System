CREATE DATABASE  IF NOT EXISTS `library_project` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `library_project`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: library_project
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `board_free`
--

DROP TABLE IF EXISTS `board_free`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `board_free` (
  `작성자` varchar(5) NOT NULL,
  `회원번호` varchar(12) NOT NULL,
  `제목` varchar(20) NOT NULL,
  `내용` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `board_free`
--

LOCK TABLES `board_free` WRITE;
/*!40000 ALTER TABLE `board_free` DISABLE KEYS */;
/*!40000 ALTER TABLE `board_free` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `board_notice`
--

DROP TABLE IF EXISTS `board_notice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `board_notice` (
  `제목` varchar(20) NOT NULL,
  `내용` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `board_notice`
--

LOCK TABLES `board_notice` WRITE;
/*!40000 ALTER TABLE `board_notice` DISABLE KEYS */;
INSERT INTO `board_notice` VALUES ('test','test'),('test22','test22'),('test3','test3'),('일이삼사 도서관에 오신 것을 환영합니','공지 내용입니다.'),('일이삼사 도서관 공지 테스트 입니다.','공지 내용입니다.'),('일이삼사 도서관 공지 테스트 입니다.','공지 내용입니다.');
/*!40000 ALTER TABLE `board_notice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `board_qna`
--

DROP TABLE IF EXISTS `board_qna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `board_qna` (
  `회원번호` varchar(12) NOT NULL,
  `작성자` varchar(5) NOT NULL,
  `회원EMail` varchar(30) NOT NULL,
  `제목` varchar(20) NOT NULL,
  `내용` varchar(200) NOT NULL,
  `답변` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`작성자`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `board_qna`
--

LOCK TABLES `board_qna` WRITE;
/*!40000 ALTER TABLE `board_qna` DISABLE KEYS */;
INSERT INTO `board_qna` VALUES ('test','test','m_file@naver.com','test','test','test'),('test2','test2','m_file@naver.com','test2','test2','test2885'),('test4','test4','m_file@naver.com','test4','test3','test3');
/*!40000 ALTER TABLE `board_qna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `관리번호` varchar(12) NOT NULL,
  `이름` varchar(45) NOT NULL,
  `ISBN` varchar(45) DEFAULT NULL,
  `저자` varchar(20) DEFAULT NULL,
  `출판일자` varchar(20) DEFAULT NULL,
  `출판사` varchar(20) DEFAULT NULL,
  `도서상태` varchar(20) DEFAULT NULL,
  `대출여부` varchar(10) DEFAULT NULL,
  `도서가격` varchar(20) DEFAULT NULL,
  `페이지수` varchar(10) DEFAULT NULL,
  `도서소개` varchar(200) DEFAULT NULL,
  `대출한_회원번호` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES ('014319251122','트렌드 코리아 2023','9788959897094','추예린 외 10명','20221005','미래의창','이상 무','대출 가능','17100','424','남다른 치열함과 기민함으로 새롭게 무장하라',''),('024319251122','조국의 법고전 산책','9788997780518','조국','20221109','오마이북','이상 무','대출 가능','19800','468','열다섯 권의 고전, 그 사상가들을 만나다',''),('034319251122','천 원을 경영하라','9791165346485','박정부','20221201','쌤앤파커스','이상 무','대출 가능','14400','276','국민가게 다이소의 성공 비결',''),('044319251122','흔한남매 12','9791168414471','백난도','20221130','미래엔아이세움','이상 무','대출 가능','13050','276','흔한남매가 선물하는 포근포근한 웃음과 공간',''),('054319251122','아버지의 해방일기','9788936438838','정지아','20220902','창비','이상 무','대출 가능','12000','268','유시민 작가 추천, 울고 웃는 사이 번지는 삶의 온기',''),('064319251122','불편한 편의점 2','9791161571379','김호연','20220810','나무옆의자','이상 무','대출 가능','12600','320','마음이 머물고 사연이 오가는, 편의점의 시간이 다시 열린다!',''),('074319251122','역행자','9788901260716','자청','20220530','웅진지식하우스','이상 무','대출 가능','15750','314','라이프해커 자청의 인생 역주행 공식',''),('084319251122','주택청약의 모든 것','9791157846276','한국부동산원','20221111','한빛비즈','이상 무','대출 가능','10800','232','한국부동산원 청약홈 공식 가이드',''),('094319251122','이상한 과자 가게 전천당 16','9791164064748','히로시마 레이코','20221125','길벗스쿨','이상 무','대출 가능','11700','160','베니코와 천재 박사의 맞대결',''),('104319251122','불편한 편의점','9791161571188','김호연','20210420','나무옆의자','이상 무','대출 가능','12600','268','힘들게 살아낸 오늘을 위로하는 편의점의 밤',''),('114319251122','블루 아카이브 코믹 앤솔로지 Vol.1&Vol.2 세트','9791127866358','김덕진/NEXON GAMES','20221120','디앤씨미디어','이상 무','대출 가능','18000','304','대인기 스마트폰 RPG 첫 공식 코믹 앤솔로지',''),('124319251122','하얼빈','9788954699914','김훈','20220803','문학동네','이상 무','대출 가능','14400','308','김훈이 그려낸 인간 안중근',''),('134319251122','이은경쌤의 초등어휘일력 365','9791192625300','이은경','20221028','포레스트북스','이상 무','대출 가능','16920','384','교육부 지정 국어 문학 어휘 완전정복!',''),('144319251122','만일 내가 인생을 다시 산다면 (10만부 기념 스페셜 에디션)','9791190538510','김혜남','20221111','메이븐','이상 무','대출 가능','15480','280','그냥 재미있게 살아라!',''),('154319251122','Go Go 카카오프렌즈 26 폴란드','9788950941901','김미영','20221123','아울북','이상 무','대출 가능','13320','176','폴란드로 시간여행을 떠난 카카오프렌즈',''),('164319251122','이 책은 돈 버는 법에 관한 이야기','9791189686536','고명환','20220919','라곰','이상 무','대출 가능','15120','268','제대로 된 돈을 버는 법!',''),('174319251122','흔한남매 과학 탐험대 6 물리 2','9788934946793','권태균, 이현진','20221122','주니어김영사','이상 무','대출 가능','12600','204','흔한남매와 떠나는 흥미진진 과학 대모험!',''),('184319251122','그리스 로마 신화 31','9788950941567','박시연','20221123','아울북','이상 무','대출 가능','13500','192','믿고 보는 아울북 교양 만화!',''),('194319251122','세상에서 가장 쉬운 본질육아','9788950941819','지나영','20220928','21세기북스','이상 무','대출 가능','16920','284','지나영 교수가 알려주는 육아원칙',''),('204319251122','우리, 편하게 말해요','9788901264776','이금희','20221021','웅진지식하우스','이상 무','대출 가능','15300','308','이금희의 말하기 노하우',''),('214319251122','나의 월급 독립 프로젝트 (리마스터 에디션)','9788901265506','유목민','20221028','리더스북','이상 무','대출 가능','17820','332','더욱 업그레이드 되어 돌아왔다!',''),('224319251122','키위엔 영어회화 하루 5분의 기적','9791198002907','박강준','20221205','키위엔','이상 무','대출 가능','17550','300','특허로 검증된 영어합슥법으로 특별한 영어공부 시작',''),('234319251122','랑랑 형제 떡집','9788949162485','김리리','20221026','비룡소','이상 무','대출 가능','9900','88','한밤중 누군가 떡집의 문을 두드렸다!',''),('244319251122','작은 아씨들: 정서경 대본집 세트','9791190738507','정서경','20221209','플레인','이상 무','대출 가능','43200','쪽수확인중','정서경 작가표 환상 동화, 드라마 <작은 아씨들> 대본집',''),('254319251122','마흔에 읽는 니체','9791192300245','장재형','20220901','유노북스','이상 무','대출 가능','14400','272','니체, 40을 위한 철학자',''),('264319251122','원씽 THE ONE THING','9788997575169','게리 켈러, 제이 파파산','20130830','비즈니스북스','이상 무','대출 가능','12600','280','버리고, 선택하고, 집중하라!',''),('274319251122','에그박사 8','9791168414075','에그박사 원저 / 박송이','20221110','미래엔아이세움','이상 무','대출 가능','13050','152','흡혈 곤충에서 흡혈박쥐까지! 무시무시한 생물 특집',''),('284319251122','파친코 2','9791168340541','이민진','20220825','인플루엔셜','이상 무','대출 가능','14220','380','역사에 외면당한 재일조선인 가족의 대서사극',''),('294319251122','파친코 1','9791168340510','이민진','20220727','인플루엔셜','이상 무','대출 가능','14220','388','역사에 외면당한 재일조선인 가족의 대서사극',''),('304319251122','세상의 마지막 기차역','9791191043754','무라세 다케시','20220511','모모','이상 무','대출 가능','12600','324','사랑하는 사람을 사고로 잃은 후 벌어지는 기적 같은 이야기',''),('test','test','test','test','test','test','이상 무','대출 가능','test','test','test',NULL);
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `member` (
  `회원번호` varchar(12) NOT NULL,
  `이름` varchar(5) NOT NULL,
  `아이디` varchar(10) NOT NULL,
  `비밀번호` varchar(20) NOT NULL,
  `성별` varchar(2) NOT NULL,
  `주소` varchar(50) DEFAULT NULL,
  `연락처` varchar(14) NOT NULL,
  `생년월일` varchar(10) NOT NULL,
  `이메일` varchar(30) NOT NULL,
  `가입일` varchar(10) NOT NULL,
  `대출권수` varchar(10) DEFAULT NULL,
  `회원상태` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`회원번호`,`아이디`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
INSERT INTO `member` VALUES ('111111111112','테스트','test','test','여자','경기도','010-0000-0001','1900-01-01','test@test.com','2000-01-01','0','정상'),('111111111112','테스트','test3','test3','여자','경기도','010-0000-0001','1900-01-01','test@test.com','2000-01-01','0','정상'),('2211253659','이민혁','min3659111','test','남자','테스트','010-0000-0000','1999-05-19','m_file@naver.com','2022-11-25','0','정상');
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'library_project'
--

--
-- Dumping routines for database 'library_project'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-28  1:22:14
