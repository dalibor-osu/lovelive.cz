SELECT 'CREATE DATABASE love_live_cz' WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'love_live_cz')\gexec

DO $$ BEGIN
    IF NOT EXISTS (SELECT * FROM pg_user WHERE usename = 'love_live_cz') THEN
        CREATE ROLE love_live_cz LOGIN SUPERUSER password 'HteVuDclI4pMTiUMRp8fQN3wXfqMRf';
    END IF;
END $$;