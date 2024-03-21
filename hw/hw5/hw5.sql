use ch4
go

--1.检索年龄大于21的男学生学号和姓名
SELECT snum,sname FROM S WHERE age>21 AND gender='男'

--2.检索“李强”同学没有选修的课程的课程号
(SELECT cnum FROM C)
EXCEPT
(SELECT cnum FROM S,SC WHERE S.snum=SC.snum AND S.sname='李强')

--3.检索选修了“程军”老师所授课程之一的学生姓名
SELECT DISTINCT sname FROM S,SC,C WHERE S.snum=SC.snum AND SC.cnum=C.cnum AND C.teacher='程军'

--4.检索至少选修两门课程的学生学号
SELECT DISTINCT sc1.snum 
FROM SC sc1,SC sc2,S 
WHERE sc1.snum=sc2.snum AND sc1.cnum<>sc2.cnum AND sc1.snum=S.snum

--5.检索选修了课程k1或课程k2的学生学号
SELECT DISTINCT snum FROM SC WHERE SC.cnum='k1' OR SC.cnum='k2'

--6.检索至少选修了数据库和计算机应用基础的学生名单
(SELECT sname FROM S,SC,C WHERE s.snum=sc.snum AND sc.cnum=c.cnum AND c.cname='数据库原理')
INTERSECT
(SELECT sname FROM S,SC,C WHERE s.snum=sc.snum AND sc.cnum=c.cnum AND c.cname='计算机应用基础')

--7.检索至少选修了3号学生所学课程的学生名单
SELECT sname FROM S
WHERE NOT EXISTS(
   SELECT * FROM SC sc1
   WHERE snum=3 AND NOT EXISTS
   (
       SELECT * FROM SC sc2
       WHERE sc2.snum=s.snum AND sc2.cnum=Sc1.cnum
    )
)

--8.检索选修了“程军”老师所授课程的学生姓名
SELECT sname FROM S
WHERE NOT EXISTS(
   SELECT * FROM C
   WHERE teacher='程军' AND NOT EXISTS
   (
       SELECT * FROM sc 
       WHERE sc.snum=s.snum AND sc.cnum=c.cnum
    )
)
