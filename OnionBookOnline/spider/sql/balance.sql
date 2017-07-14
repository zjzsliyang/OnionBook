--------------------------------------------------------
--  File created - Friday-July-14-2017   
--------------------------------------------------------
-- Unable to render TRIGGER DDL for object ONIONBOOK.BALANCETRIGGER with DBMS_METADATA attempting internal generator.
CREATE TRIGGER BALANCETRIGGER BEFORE UPDATE OF "Balance" ON "AspNetUsers" 
    for each row
        begin
           if :old."Balance" > :new."Balance" then
                :new."Credits" := :new."Credits" + :old."Balance" - :new."Balance";
           end if;
        end;
