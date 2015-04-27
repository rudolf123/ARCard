DROP TABLE IF EXISTS "firms";
CREATE TABLE "firms" ("id" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , "name" TEXT check(typeof("name") = 'text') , "contact" TEXT check(typeof("contact") = 'text') , "info" TEXT check(typeof("info") = 'text') , "partners" TEXT check(typeof("partners") = 'text') );
DROP TABLE IF EXISTS "presentations";
CREATE TABLE "presentations" ("id" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , "firm_id" INTEGER, "name" TEXT check(typeof("name") = 'text') , "info" TEXT check(typeof("info") = 'text') );
