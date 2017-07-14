--------------------------------------------------------
--  File created - Friday-July-14-2017   
--------------------------------------------------------
-- Unable to render TRIGGER DDL for object ONIONBOOK.DSTOCKTRIGGER with DBMS_METADATA attempting internal generator.
CREATE TRIGGER DSTOCKTRIGGER AFTER DELETE ON CONTAIN 
    for each row
        begin
           UPDATE BOOK SET BOOK.STOCK = (BOOK.STOCK + :old.AMOUNT) WHERE BOOK.BOOKID = :old.BOOKID;
        end;
