/*ʵ���� ��ͼ���洢���̺ʹ�����*/
--���� 2020111235
use university
go

--1.������ͼ������ͼ��������ݲ�ѯ����
--��1����university���ݿ��ϴ�����ͼViewA����ɡ���ѯ��ѡ�μ�¼��ѧ��ѧ�š��γ̺š��γ����ơ��ɼ�����������������
CREATE VIEW ViewA
AS
SELECT snum,sections.cnum,cname,score
FROM sc JOIN sections ON sc.secnum =sections.secnum 
        JOIN course ON course.cnum=sections.cnum

--��2����������ͼ�Ļ�������ɲ�ѯ����ѯ����ѧ��������Ŀγ�����
SELECT cname  
FROM ViewA 
GROUP BY cname
HAVING MIN(score)>=60


--2.�洢���̵Ľ�����ִ��
--��1�������洢����ProcA���书��Ϊ��ʾ����ѧ���Ļ�����Ϣ
CREATE PROC ProcA
AS
SELECT *
FROM student
--ִ��ProcA
EXEC ProcA

--��2�������洢����ProcB���书���ǲ�ѯ���������������Ϣ����֪�������ڵ�ǰ��λ��Ϣ����ѧ����Ϣ
CREATE PROC ProcB
@_year char(4)
AS
SELECT *
FROM student
WHERE year(birthday)=@_year
--ִ��ProcB
DECLARE @year char(4)
SET @year='1994'
EXEC ProcB @year

--��3�������洢����ProcC���书���ǲ�ѯ����ѧ�ŵ�ѧ���Ŀγ�ƽ���ɼ���ѡ�޿γ̵������Ͳ�����γ�����
CREATE PROC ProcC
@_snum char(4),@_avg int OUTPUT,@_selected_course int OUTPUT,@_failed_course int OUTPUT
AS
SELECT @_avg=AVG(score),@_selected_course=COUNT(cnum),@_failed_course=sum(1-score/60)
FROM sc JOIN sections ON sc.secnum =sections.secnum 
WHERE snum=@_snum
--ִ��ProcC
DECLARE @snum char(4),@avg int,@selectedCourse int,@failedCourse int
SET @snum='s001'
EXEC ProcC @snum,@avg OUTPUT,@selectedCourse OUTPUT,@failedCourse OUTPUT
PRINT @snum + '��ƽ���ɼ�Ϊ' + cast(@avg as char(2)) + '��ѡ������Ϊ' + cast(@selectedCourse as char(2)) + ',����������Ϊ' + cast(@failedCourse as char(2))


--3.����һ�鴥�����������һ���Ҫ�����ݲ�����֤�������Ĺ���
--��1���Զ���һ��������TA�����ѡ�α�SC����snum�Ĳ��������Կ���
CREATE TRIGGER TA
ON sc
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @_snum char(4)
	SELECT @_snum=inserted.snum FROM inserted 
	IF NOT EXISTS(SELECT * FROM Student WHERE student.snum = @_snum)
		BEGIN
		PRINT '����������'
		ROLLBACK
		END
	ELSE
		PRINT '�������ݳɹ�'
END
--��֤TA
--�����ѧ�Ų�����
INSERT INTO SC VALUES('S009','11601',89)
--���µ�ѧ�Ų�����
UPDATE SC SET snum='s101' where snum='s001' and secnum='11601'
--����ѧ�źͿγ̺Ŷ�����
INSERT INTO SC VALUES('S005','12601',87) 
--���µ�ѧ�Ŵ���
UPDATE SC SET snum='s007' where snum='s005' and secnum='12601'

--��2���Զ���һ��������TB�����ѧ����student�����������Կ��ơ�
--����Ҫ��Ϊ��������䲻��14~35�귶Χ�ڣ��򱨡�����Խ�磡��������ʾ��Ϣ��������ʾ������¼��ɹ�����
CREATE TRIGGER TB
ON student
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @_age int
	SELECT  @_age = DATEDIFF(YEAR,birthday,GETDATE()) FROM inserted 
	IF @_age < 14 or @_age > 35
		BEGIN
		PRINT '����Խ��'
		ROLLBACK
		END
	ELSE
		PRINT '����¼��ɹ�'
END
--��֤TB
--��������Խ���¼
INSERT INTO student VALUES('s009','���ٹ�','��','�����','1920-1-1','023-12345678')
--�����¼
INSERT INTO student VALUES('s009','���ٹ�','��','�����','1995-1-1','023-12345678')
--��������Խ���¼
UPDATE student SET birthday='1920-1-1'
WHERE snum='s009'
--���¼�¼
UPDATE student SET birthday='1996-1-1'
WHERE snum='s009'

--��3���Զ���һ��������TC����ɿγ̱�course�����������Կ��ơ�
--����Ҫ��Ϊ������γ̶����Ľ̲Ĳ��ǸߵȽ��������硢�廪��ѧ�����硢������ѧ�������ͬ�ô�ѧ���������ģ��򱨡�����ָ�������磬���ܶ�������������ʾ��Ϣ�����򱨡������ɹ�������Ϣ
CREATE TRIGGER TC
ON course
FOR INSERT,UPDATE
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM inserted WHERE Right(Rtrim(textbook),7) in('�ߵȽ���������', '�廪��ѧ������','������ѧ������','ͬ�ô�ѧ������'))
		BEGIN
		PRINT '����ָ�������磬���ܶ�����'
		ROLLBACK
		END
	ELSE 
		PRINT '�����ɹ���'
END
--��֤TC
--���벻����Ŀα�
INSERT INTO course VALUES('c137','����ѧϰ',4,'���޿�','�����ϵ','������ѧϰ�������ӹ�ҵ������')
--��������Ŀα�
INSERT INTO course VALUES('c137','����ѧϰ',4,'���޿�','�����ϵ','������ѧϰ�����ߵȽ���������')

--(4)�Զ���һ��������TD�����ѡ�α�SC�����������Կ��ơ�
--�����û���ѡ�α��в�������һ��ѡ�μ�¼ʱ�����ͬһ��ѧ�ŵ�ѡ�μ�¼�У�������ͬһ�ſγ̵Ķ����ţ���ֱ��ɾ��SC���е����²������µļ�¼�������ύSC���ж�Ӧ�������µļ�¼����ѡ���⣩
CREATE TRIGGER TD ON SC
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @_cnum char(4),@_snum char(4),@_i int
	SELECT @_cnum=cnum,@_snum=snum FROM inserted JOIN sections ON inserted.secnum =sections.secnum 
	SELECT @_i=count(*) FROM SC JOIN sections on sc.secnum =sections.secnum AND snum=@_snum AND cnum=@_cnum
	IF @_i > 1
		BEGIN
		PRINT '�ÿγ���ѡ��������������'
		ROLLBACK
		END
	ELSE
		PRINT '�����ɹ���'
END 
GO
--��֤TD
--�����¼ʧ��
INSERT INTO SC VALUES('s001','11602',85)
--���¼�¼ʧ��
UPDATE SC SET secnum='12002' WHERE snum='s001' and secnum='11601'
--�����¼�ɹ�
INSERT INTO SC VALUES('s006','13001',85)
--���¼�¼�ɹ�
UPDATE SC SET secnum='12601' WHERE snum='s005' and secnum='11602'


