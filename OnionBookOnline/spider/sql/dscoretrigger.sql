--------------------------------------------------------
--  File created - Friday-July-14-2017   
--------------------------------------------------------
-- Unable to render TRIGGER DDL for object ONIONBOOK.DSCORETRIGGER with DBMS_METADATA attempting internal generator.
CREATE TRIGGER DSCORETRIGGER AFTER DELETE ON OCOMMENT 
    for each row
        begin
           UPDATE BOOK SET BOOK.SCORE = (BOOK.SCORE * 101  - :old.SCORE)/100 WHERE BOOK.BOOKID = :old.BOOKID;
        end;
