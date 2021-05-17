CREATE OR REPLACE PROCEDURE SP_USER_PROFILE(pUserId         In out Nvarchar2,
                                            pPassword       In Nvarchar2,
                                            pServiceFlag    OUT Nvarchar2,
                                            perror_code     OUT NVARCHAR2,
                                            perror_msg      OUT NVARCHAR2,
                                            presult_set_cur OUT SYS_REFCURSOR) IS

  vCount NUMBER(1) := 0;

BEGIN

  OPEN presult_set_cur FOR
    select t.user_id, t.user_password, t.service_flag
      from USER_PROFILE t
     where t.user_id = pUserId
       and t.user_password = pPassword;

EXCEPTION
  WHEN OTHERS THEN
    perror_code := SQLCODE;
    perror_msg  := SQLERRM;

END SP_USER_PROFILE;
