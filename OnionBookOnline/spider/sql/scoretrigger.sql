--------------------------------------------------------
--  File created - Friday-July-14-2017   
--------------------------------------------------------
-- Unable to render TRIGGER DDL for object ONIONBOOK.SCORETRIGGER with DBMS_METADATA attempting internal generator.
CREATE TRIGGER SCORETRIGGER AFTER DELETE ON OCOMMENT 
    for each row
        begin
           UPDATE BOOK SET BOOK.SCORE = (BOOK.SCORE * 100 + :new.SCORE)/101 WHERE BOOK.BOOKID = :new.BOOKID;
        end;
