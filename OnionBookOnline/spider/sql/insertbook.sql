--------------------------------------------------------
--  File created - Friday-July-14-2017   
--------------------------------------------------------
-- Unable to render PROCEDURE DDL for object ONIONBOOK.INSERTBOOK with DBMS_METADATA attempting internal generator.
CREATE PROCEDURE INSERTBOOK (
    pisbn in VARCHAR2,
    pname in VARCHAR2,
    pprimaryid in VARCHAR2,
    psecondaryid in VARCHAR2,
    ppublisher in VARCHAR2,
    pprice in NUMBER,
    ppages in NUMBER,
    pdiscount in NUMBER,
    pstock in NUMBER,
    pscore in NUMBER,
    ppublishingdate in VARCHAR2,
    psale in NUMBER,
    pintroduction in CLOB,
    pauthorname in VARCHAR2,
    ppath in VARCHAR2
    ) 
AS 
countN1 int;
countN2 int;
newauthorid VARCHAR2(20);
newbookid VARCHAR2(20);
BEGIN
  select count(*) into countN1 from book where isbn = pisbn;
  if countN1 = 0 then
    INSERT INTO BOOK(isbn,name,primaryid,secondaryid,publisher,price,pages,discount,stock,score,publishingdate,sale,introduction)
    VALUES(pisbn,pname,pprimaryid,psecondaryid,ppublisher,pprice,ppages,pdiscount,pstock,pscore,ppublishingdate,psale,pintroduction);
    select bookid into newbookid from book where isbn = pisbn;
    insert into picture values(newbookid,'00',ppath);
    
    select count(*) into countN2 from author where name = pauthorname;
    if countN2 = 0 then
      insert into AUTHOR(NAME) values(pauthorname);
    end if;
    
    select AUTHORID into newauthorid from AUTHOR WHERE NAME = pauthorname;
    insert into WRITE values(newauthorid,newbookid);

  end if;

END INSERTBOOK;
