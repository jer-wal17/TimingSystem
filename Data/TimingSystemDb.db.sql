BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "drivers" (
	"driverkey"	INTEGER NOT NULL UNIQUE,
	"name"	TEXT,
	"number"	INTEGER UNIQUE,
	"class"	TEXT,
	PRIMARY KEY("driverkey" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "times" (
	"timeskey"	INTEGER NOT NULL UNIQUE,
	"driverkey"	INTEGER,
	"time_ms"	INTEGER,
	"cones"	INTEGER NOT NULL DEFAULT 0,
	"dnf"	INTEGER NOT NULL DEFAULT 0 CHECK("dnf" IN (0, 1)),
	PRIMARY KEY("timeskey" AUTOINCREMENT),
	CONSTRAINT "fk_driverkey" FOREIGN KEY("driverkey") REFERENCES "drivers"("driverkey")
);
INSERT INTO "drivers" VALUES (1,'Court',17,'HS');
INSERT INTO "times" VALUES (1,1,56589,0,0);
INSERT INTO "times" VALUES (2,1,55423,1,0);
CREATE UNIQUE INDEX IF NOT EXISTS "driverkey_index" ON "drivers" (
	"driverkey"	ASC
);
CREATE UNIQUE INDEX IF NOT EXISTS "timeskey_index" ON "times" (
	"timeskey"	ASC
);
COMMIT;
