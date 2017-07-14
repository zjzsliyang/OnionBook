--------------------------------------------------------
--  File created - Friday-July-14-2017   
--------------------------------------------------------
-- Unable to render TRIGGER DDL for object ONIONBOOK.STOCKTRIGGER with DBMS_METADATA attempting internal generator.
CREATE TRIGGER STOCKTRIGGER AFTER INSERT ON CONTAIN 
    for each row
        begin
           UPDATE BOOK SET BOOK.STOCK = (BOOK.STOCK - :new.AMOUNT) WHERE BOOK.BOOKID = :new.BOOKID;
        end;
