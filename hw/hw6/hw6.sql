/*实验五 视图、存储过程和触发器*/
--马靖淳 2020111235
use university
go

--1.定义视图并在视图上完成数据查询功能
--（1）在university数据库上创建视图ViewA，完成“查询有选课记录的学生学号、课程号、课程名称、成绩”的数据搜索功能
CREATE VIEW ViewA
AS
SELECT snum,sections.cnum,cname,score
FROM sc JOIN sections ON sc.secnum =sections.secnum 
        JOIN course ON course.cnum=sections.cnum

--（2）在上述视图的基础上完成查询：查询所有学生都及格的课程名称
SELECT cname  
FROM ViewA 
GROUP BY cname
HAVING MIN(score)>=60


--2.存储过程的建立和执行
--（1）建立存储过程ProcA，其功能为显示所有学生的基本信息
CREATE PROC ProcA
AS
SELECT *
FROM student
--执行ProcA
EXEC ProcA

--（2）建立存储过程ProcB，其功能是查询出给定出生年份信息（已知出生日期的前四位信息）的学生信息
CREATE PROC ProcB
@_year char(4)
AS
SELECT *
FROM student
WHERE year(birthday)=@_year
--执行ProcB
DECLARE @year char(4)
SET @year='1994'
EXEC ProcB @year

--（3）建立存储过程ProcC，其功能是查询给定学号的学生的课程平均成绩、选修课程的门数和不及格课程门数
CREATE PROC ProcC
@_snum char(4),@_avg int OUTPUT,@_selected_course int OUTPUT,@_failed_course int OUTPUT
AS
SELECT @_avg=AVG(score),@_selected_course=COUNT(cnum),@_failed_course=sum(1-score/60)
FROM sc JOIN sections ON sc.secnum =sections.secnum 
WHERE snum=@_snum
--执行ProcC
DECLARE @snum char(4),@avg int,@selectedCourse int,@failedCourse int
SET @snum='s001'
EXEC ProcC @snum,@avg OUTPUT,@selectedCourse OUTPUT,@failedCourse OUTPUT
PRINT @snum + '的平均成绩为' + cast(@avg as char(2)) + '，选课门数为' + cast(@selectedCourse as char(2)) + ',不及格门数为' + cast(@failedCourse as char(2))


--3.建立一组触发器，并设计一组必要的数据操作验证触发器的功能
--（1）自定义一个触发器TA，完成选课表SC属性snum的参照完整性控制
CREATE TRIGGER TA
ON sc
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @_snum char(4)
	SELECT @_snum=inserted.snum FROM inserted 
	IF NOT EXISTS(SELECT * FROM Student WHERE student.snum = @_snum)
		BEGIN
		PRINT '该生不存在'
		ROLLBACK
		END
	ELSE
		PRINT '插入数据成功'
END
--验证TA
--插入的学号不存在
INSERT INTO SC VALUES('S009','11601',89)
--更新的学号不存在
UPDATE SC SET snum='s101' where snum='s001' and secnum='11601'
--插入学号和课程号都存在
INSERT INTO SC VALUES('S005','12601',87) 
--更新的学号存在
UPDATE SC SET snum='s007' where snum='s005' and secnum='12601'

--（2）自定义一个触发器TB，完成学生表student的数据完整性控制。
--具体要求为：如果年龄不在14~35岁范围内，则报“年龄越界！”错误提示信息，否则显示“数据录入成功”。
CREATE TRIGGER TB
ON student
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @_age int
	SELECT  @_age = DATEDIFF(YEAR,birthday,GETDATE()) FROM inserted 
	IF @_age < 14 or @_age > 35
		BEGIN
		PRINT '年龄越界'
		ROLLBACK
		END
	ELSE
		PRINT '数据录入成功'
END
--验证TB
--插入年龄越界记录
INSERT INTO student VALUES('s009','邓荣功','男','计算机','1920-1-1','023-12345678')
--插入记录
INSERT INTO student VALUES('s009','邓荣功','男','计算机','1995-1-1','023-12345678')
--更新年龄越界记录
UPDATE student SET birthday='1920-1-1'
WHERE snum='s009'
--更新记录
UPDATE student SET birthday='1996-1-1'
WHERE snum='s009'

--（3）自定义一个触发器TC，完成课程表course的数据完整性控制。
--具体要求为：如果课程订购的教材不是高等教育出版社、清华大学出版社、复旦大学出版社和同济大学出版社出版的，则报“不是指定出版社，不能订购！”错误提示信息，否则报“订购成功！”信息
CREATE TRIGGER TC
ON course
FOR INSERT,UPDATE
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM inserted WHERE Right(Rtrim(textbook),7) in('高等教育出版社', '清华大学出版社','复旦大学出版社','同济大学出版社'))
		BEGIN
		PRINT '不是指定出版社，不能订购！'
		ROLLBACK
		END
	ELSE 
		PRINT '订购成功！'
END
--验证TC
--插入不满足的课本
INSERT INTO course VALUES('c137','机器学习',4,'必修课','计算机系','《机器学习》，电子工业出版社')
--插入满足的课本
INSERT INTO course VALUES('c137','机器学习',4,'必修课','计算机系','《机器学习》，高等教育出版社')

--(4)自定义一个触发器TD，完成选课表SC的数据完整性控制。
--即当用户在选课表中插入或更新一条选课记录时，如果同一个学号的选课记录中，出现了同一门课程的多个班号，则直接删除SC表中的最新插入或更新的记录；否则提交SC表中对应插入或更新的记录。（选做题）
CREATE TRIGGER TD ON SC
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @_cnum char(4),@_snum char(4),@_i int
	SELECT @_cnum=cnum,@_snum=snum FROM inserted JOIN sections ON inserted.secnum =sections.secnum 
	SELECT @_i=count(*) FROM SC JOIN sections on sc.secnum =sections.secnum AND snum=@_snum AND cnum=@_cnum
	IF @_i > 1
		BEGIN
		PRINT '该课程已选！操作被撤消！'
		ROLLBACK
		END
	ELSE
		PRINT '操作成功！'
END 
GO
--验证TD
--插入记录失败
INSERT INTO SC VALUES('s001','11602',85)
--更新记录失败
UPDATE SC SET secnum='12002' WHERE snum='s001' and secnum='11601'
--插入记录成功
INSERT INTO SC VALUES('s006','13001',85)
--更新记录成功
UPDATE SC SET secnum='12601' WHERE snum='s005' and secnum='11602'


