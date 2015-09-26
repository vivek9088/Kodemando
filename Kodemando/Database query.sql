-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.45-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema test
--

CREATE DATABASE IF NOT EXISTS test;
USE test;

--
-- Definition of table `exam`
--

DROP TABLE IF EXISTS `exam`;
CREATE TABLE `exam` (
  `eid` varchar(10) NOT NULL,
  `ename` varchar(25) default NULL,
  `duration` int(11) default NULL,
  `tot_quest` int(11) default NULL,
  PRIMARY KEY  (`eid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `exam`
--

/*!40000 ALTER TABLE `exam` DISABLE KEYS */;
INSERT INTO `exam` (`eid`,`ename`,`duration`,`tot_quest`) VALUES 
 ('E001','C#',15,6),
 ('E002','C++',20,10),
 ('E003','C',15,6),
 ('E004','Asp.Net',20,10),
 ('E005','Java',20,10);
/*!40000 ALTER TABLE `exam` ENABLE KEYS */;


--
-- Definition of table `faculty`
--

DROP TABLE IF EXISTS `faculty`;
CREATE TABLE `faculty` (
  `fid` int(11) NOT NULL auto_increment,
  `fname` varchar(25) default NULL,
  `course_take` varchar(20) default NULL,
  `username` varchar(20) default NULL,
  `password` varchar(25) default NULL,
  `number` int(11) default NULL,
  `email` varchar(50) default NULL,
  PRIMARY KEY  (`fid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `faculty`
--

/*!40000 ALTER TABLE `faculty` DISABLE KEYS */;
/*!40000 ALTER TABLE `faculty` ENABLE KEYS */;


--
-- Definition of table `login`
--

DROP TABLE IF EXISTS `login`;
CREATE TABLE `login` (
  `id` int(10) unsigned NOT NULL,
  `uname` varchar(45) NOT NULL,
  `pwd` varchar(45) NOT NULL,
  `role` varchar(45) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` (`id`,`uname`,`pwd`,`role`) VALUES 
 (1,'admin','*4ACFE3202A5FF5CF467898FC58AAB1D615029441','Admin'),
 (10158,'vinvik','*B82215B2D13FA1D58DF5CFA3F59A223979FFF721','Student');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;


--
-- Definition of table `stud_score`
--

DROP TABLE IF EXISTS `stud_score`;
CREATE TABLE `stud_score` (
  `rowid` int(11) NOT NULL auto_increment,
  `cid` int(11) NOT NULL,
  `cname` varchar(25) NOT NULL,
  `course_reg` varchar(10) NOT NULL,
  `score` int(11) default '0',
  PRIMARY KEY  (`rowid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stud_score`
--

/*!40000 ALTER TABLE `stud_score` DISABLE KEYS */;
/*!40000 ALTER TABLE `stud_score` ENABLE KEYS */;


--
-- Definition of table `student`
--

DROP TABLE IF EXISTS `student`;
CREATE TABLE `student` (
  `name` varchar(20) default NULL,
  `course_name` varchar(25) default NULL,
  `id` int(11) NOT NULL,
  `mobnum` varchar(10) default NULL,
  `email` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student`
--

/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` (`name`,`course_name`,`id`,`mobnum`,`email`) VALUES 
 ('vivek','C++',10158,'4126361699','vivek@gmail.com');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;


--
-- Definition of table `test`
--

DROP TABLE IF EXISTS `test`;
CREATE TABLE `test` (
  `ecode` varchar(10) default NULL,
  `qno` int(11) NOT NULL,
  `quest` longtext,
  `opt1` longtext,
  `opt2` longtext,
  `opt3` longtext,
  `opt4` longtext,
  `ans` int(11) default NULL,
  `mark` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `test`
--

/*!40000 ALTER TABLE `test` DISABLE KEYS */;
INSERT INTO `test` (`ecode`,`qno`,`quest`,`opt1`,`opt2`,`opt3`,`opt4`,`ans`,`mark`) VALUES 
 ('E005',1,'Which collection class allows you to associate its elements with key values, and allows you to retrieve objects in FIFO (first-in, first-out) sequence?','java.util.ArrayList','java.util.LinkedHashMap','java.util.HashMap','java.util.TreeMap',2,2),
 ('E005',2,'Which interface does java.util.HashTable implement? ','Java.util.Map','Java.util.List','Java.util.HashTable','Java.util.Collection',2,2),
 ('E003',1,'Inline functions are invoked at the time of','Run time','Compile time','Depends on how it is invoked ','Both b and c above	',2,2),
 ('E005',3,'What will be the output of the program? ','public class Test      {     public int aMethod()     {       static int i = 0;      i++;         return i;       }','public static void main(String args[])     {             Test test = new Test();         test.aMethod();   int j = test.aMethod();          System.out.println(j);      }  }','0	 1	2','Compilation fails',4,2),
 ('E003',2,'Which classes allow primitive types to be accessed as objects?','Storage','Virtual',' Friend','Wrapper',4,2),
 ('E003',3,'What happens when a pointer is deleted twice? ',' It can abort the program',' It can cause a failure','It can cause an error',' It can cause a trap',4,2),
 ('E005',4,'What will be the output of the program? public class Test     {        public static void main(String args[])  {             int i = 1, j = 0;              switch(i)               {                  case 2: j += 6;                  case 4: j += 1;                 default: j += 2;                   case 0: j += 4;       }              System.out.println(\"j = \" + j);     }   }','0','2','4','6',4,2),
 ('E005',6,'What will be the output of the program?    public class ObjComp      {    public static void main(String [] args )    {   int result = 0;    ObjComp oc = new ObjComp();    Object o = oc;    if (o == oc)      result = 1;      if (o != oc)      result = result + 10;     if (o.equals(oc) )     result = result + 100;    if (oc.equals(o) )     result = result + 1000;     System.out.println(\"result = \" + result);      }  }','1','10','101','1101',4,5),
 ('E005',7,'What will be the output of the program?    String x = new String(\"xyz\");  y = \"abc\";  x = x + y;    how many String objects have been created?','2','3','4','5',2,2),
 ('E005',8,'Which of the following are true statements?    1) The Iterator interface declares only three methods: hasNext, next  and remove.   2) The ListIterator interface extends both the List and Iterator  interfaces.    3) The ListIterator interface provides forward and backward  iteration capabilities.   4) The ListIterator interface provides the ability to modify the  List during iteration.    5) The ListIterator interface provides the ability to determine its  position in the List.','2, 3, 4 and 5',' 1, 3, 4 and 5','3, 4 and 5','1, 2 and 3',2,3),
 ('E005',9,'What will be the output of the program?    public class ExamQuestion7    {     static int j;     static void methodA(int i)     {      boolean b;    do      {    b = i<10 | methodB(4); /* Line 9 */    b = i<10 || methodB(8);  /* Line 10 */    }while (!b);     }   static boolean methodB(int i)   {     j += i;      return true;    }          public static void main(String[] args)   {             methodA(0);              System.out.println( \"j = \" + j );          }  }','j=0','j=4','j=8','The code will run with no output',2,2),
 ('E005',10,'Which is a valid declarations of a String?','String s1 = null;','String s2 = \"null\";','String s3 = (String) \"abc\";','String s4 = (String) \"ufeed\";',1,2),
 ('E005',5,'Which statement is true?','Programs will not run out of memory.','Objects that will never again be used are eligible for garbage  collection.','Objects that are referred to by other objects will never be garbage  collected. ','Objects that can be reached from a live thread will never be garbage collected.',4,2),
 ('E003',4,'What happens when a pointer is deleted twice?',' It can abort the program','It can cause a failure','It can cause an error','It can cause a trap',4,2),
 ('E003',5,'What is deep copy?',' A deep copy creates a copy of the dynamically allocated objects too.','A deep copy just copies the values of the data as they are.','A deep copy creates a copy of the statically allocated objects too','Both b and c above',1,2),
 ('E002',1,'Which of the following can be facilitated by the Inheritance mechanism? 1) Use the existing functionality of base class.     2) Overrride the existing functionality of base class.     3) Implement new functionality in the derived class.     4) Implement polymorphic behaviour.     5) Implement containership.','1,2,3','3,4','2,4,5','3,5',1,2),
 ('E002',2,'public void test(int x)  {  int odd = 1;  if(odd) /* Line 4 */        {            System.out.println(\"odd\");         }         else          {             System.out.println(\"even\");          }   }  Which statement is true?','Compilation fails',' \"odd\" will always be output','\"even\" will always be output','\"odd\" will be output for odd values of x, and \"even\" for even values',1,2),
 ('E003',6,'Which four can be thrown using the throw statement? Error  Event  Object   Throwable  Exception  RuntimeException','1,2,3 and 4','2,3,4 and 5','1, 4, 5 and 6','2, 4, 5 and 6',3,2),
 ('E004',1,'When an .aspx page is requested from the web server, the out put will be rendered to browser in following format.','HTML','XML','WML','JSP',1,2),
 ('E004',2,'What is the difference between Response.Write() andResponse.Output.Write()?','Response.Output.Write() allows you to flush output','Response.Output.Write() allows you to buffer output','Response.Output.Write() allows you to write formatted output ','Response.Output.Write() allows you to stream output',3,2),
 ('E004',3,'How do you manage states in asp.net application','Session Objects','Application Objects','Viewstate','All of the above',4,2),
 ('E004',4,'Select the caching type supported by ASP.Net','Output Caching','DataCaching','a and b','none of the above ',3,2),
 ('E004',5,'Which of the following is not a member of ADODBCommand object?','ExecuteReader','ExecuteScalar','ExecuteStream','Open',4,2),
 ('E004',6,'In ASP.Net the tracing output can shown by setting ______ Attribute.','Output','Page Output','debugOutput','traceOutput',2,2),
 ('E004',7,'What type of exception will be thrown in the code below:\r\ntry\r\n{\r\nResponse.Redirect(\"home.aspx\");\r\n}\r\ncatch()\r\n{\r\n}\r\n','System.Exception','none','ThreadAbortException','NullReferenceException',3,2),
 ('E004',8,'Setting the following properties for object in ASP.NET results in Response.Buffer = True Response.ExpiresAbsolute = Now().Subtract(New TimeSpan(1, 0, 0, 0)) Response.Expires = 0 Response.CacheControl = \"no-cache\"\r\n','The session expires','Clears the buffer area ','Avoid page to be cached','None of the Above',3,2),
 ('E004',9,'An organization has developed a web service in which the values of the forms are validated using ASP.NET application. Suppose this web service is got and used by a customer then in such a scenario which of the following is TRUE\r\n','Such a situation cannot happen at all','The customer must be having technology that run ASP.','The customer can run on any platform.','None of the Above.',3,2),
 ('E004',10,'In ASP.NET page framework an automatic way to associate page events and methods is','AutoEventWireup attribute of the Page directive is set to true','AutoEventWireup attribute of the Page directive is set to False','It is not possible to set automatically page events and methods','None of the Above',1,2),
 ('E001',1,'Which of the following can be declared in an interface? Properties\r\n    Methods\r\n    Enumerations\r\n    Events\r\n    Structures ','1,3','1,2,4','3,5','4,5',2,2),
 ('E001',2,'A class implements two interfaces each containing three methods. The class contains no instance data. Which of the following correctly indicate the size of the object created from this class?','12 bytes','24 bytes','0 byte','16 bytes',2,2),
 ('E001',3,'Which of the following statements is correct about Interfaces used in C#.NET?','All interfaces are derived from an Object class.','Interfaces can be inherited.','All interfaces are derived from an Object interface.','Interfaces can contain only method declaration.',2,2),
 ('E001',4,'What does the following C#.NET code snippet will print?\r\n\r\nint i = 0, j = 0; \r\n\r\nlabel:\r\n    i++;\r\n    j+=i;\r\nif (i < 10)\r\n{\r\n    Console.Write(i +\" \");\r\n    goto label; \r\n}','Prints 1 to 9 ','Prints 0 to 8','Prints 2 to 8','Compile error at label:',1,5),
 ('E001',5,'The C#.NET code snippet given below generates ____ numbers series as output?\r\n\r\nint i = 1, j = 1, val;\r\nwhile (i < 25)\r\n{\r\n    Console.Write(j + \" \");\r\n    val = i + j;\r\n    j = i;\r\n    i = val;\r\n}','Prime','Fibonacci','Palindrome','Even',2,2),
 ('E001',6,'What will be the output of the C#.NET code snippet given below?\r\n\r\nint i = 2, j = i;\r\nif (Convert.ToBoolean((i | j & 5) & (j - 25 * 1)))\r\n    Console.WriteLine(1); \r\nelse\r\n    Console.WriteLine(0);\r\n','0','1','Compile Error','RunTime Error',1,2),
 ('E002',3,'Which of the following is used to store data of different types?','Array','Structure','Both A and B','None of the above',2,2),
 ('E002',4,'The variables that can be used only within the function in which it is declared is called as','Global Variables','Local variables','Both A and B','None of the above',2,2),
 ('E002',5,'A function named as exforsys has three implementations associated with it. This means the function exforsys is','Overloaded','Overriding','Both A and B','None of the above',1,2),
 ('E002',6,'Which of the following denote types of polymorphism in C++?','Virutal Function','Function overloading','Operator Overloading','All the above',4,2),
 ('E002',7,'Which of the following can be used to initialize a newly declared variable from an existing variable?','Virtual Function','Namespaces','copy constructor','None of the Above',3,2),
 ('E002',8,'Pure virtual function in C++ is one in which the virtual function','has no body','has at least one member','which cannot be inherited','None of the Above',1,2),
 ('E002',9,'What is the value of variable z when the following program segment ends? int z; for(z=0; z<50; z++) {}','51','49','0','50',4,2),
 ('E002',10,'Strict parameter type checking is followed with which of the following?','Inline','Macros','Both A and B','None of the above',1,2);
/*!40000 ALTER TABLE `test` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
