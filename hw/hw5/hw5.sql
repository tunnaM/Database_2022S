use ch4
go

--1.�����������21����ѧ��ѧ�ź�����
SELECT snum,sname FROM S WHERE age>21 AND gender='��'

--2.��������ǿ��ͬѧû��ѡ�޵Ŀγ̵Ŀγ̺�
(SELECT cnum FROM C)
EXCEPT
(SELECT cnum FROM S,SC WHERE S.snum=SC.snum AND S.sname='��ǿ')

--3.����ѡ���ˡ��̾�����ʦ���ڿγ�֮һ��ѧ������
SELECT DISTINCT sname FROM S,SC,C WHERE S.snum=SC.snum AND SC.cnum=C.cnum AND C.teacher='�̾�'

--4.��������ѡ�����ſγ̵�ѧ��ѧ��
SELECT DISTINCT sc1.snum 
FROM SC sc1,SC sc2,S 
WHERE sc1.snum=sc2.snum AND sc1.cnum<>sc2.cnum AND sc1.snum=S.snum

--5.����ѡ���˿γ�k1��γ�k2��ѧ��ѧ��
SELECT DISTINCT snum FROM SC WHERE SC.cnum='k1' OR SC.cnum='k2'

--6.��������ѡ�������ݿ�ͼ����Ӧ�û�����ѧ������
(SELECT sname FROM S,SC,C WHERE s.snum=sc.snum AND sc.cnum=c.cnum AND c.cname='���ݿ�ԭ��')
INTERSECT
(SELECT sname FROM S,SC,C WHERE s.snum=sc.snum AND sc.cnum=c.cnum AND c.cname='�����Ӧ�û���')

--7.��������ѡ����3��ѧ����ѧ�γ̵�ѧ������
SELECT sname FROM S
WHERE NOT EXISTS(
   SELECT * FROM SC sc1
   WHERE snum=3 AND NOT EXISTS
   (
       SELECT * FROM SC sc2
       WHERE sc2.snum=s.snum AND sc2.cnum=Sc1.cnum
    )
)

--8.����ѡ���ˡ��̾�����ʦ���ڿγ̵�ѧ������
SELECT sname FROM S
WHERE NOT EXISTS(
   SELECT * FROM C
   WHERE teacher='�̾�' AND NOT EXISTS
   (
       SELECT * FROM sc 
       WHERE sc.snum=s.snum AND sc.cnum=c.cnum
    )
)
