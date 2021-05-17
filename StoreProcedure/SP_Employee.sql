CREATE OR REPLACE PROCEDURE SP_Employee(pEmployee_Id    In out Nvarchar2,
                                        pName           In Nvarchar2,
                                        pPosition       In Nvarchar2,
                                        pAge            In Nvarchar2,
                                        pSalary         In Nvarchar2,
                                        pOption         In nvarchar2,
                                        perror_code     OUT NVARCHAR2,
                                        perror_msg      OUT NVARCHAR2,
                                        presult_set_cur OUT SYS_REFCURSOR) IS

  vCount NUMBER(1) := 0;

BEGIN

  IF pOption = 'Insert' THEN
  
    BEGIN
    
      INSERT INTO Employee
        (employee_id, employee_name, position, age, salary)
      VALUES
        (nvl((select max(employee_id) + 1 from Employee), 1),
         pName,
         pPosition,
         pAge,
         pSalary);
    
    EXCEPTION
      WHEN OTHERS THEN
        perror_code := SQLCODE;
        perror_msg  := SQLERRM;
      
    end;
  
  ELSIF pOption = 'Update' Then
  
    BEGIN
    
      select nvl(count(a.employee_id), 0)
        into vCount
        from Employee a
       where a.employee_id = pEmployee_Id;
    
      if vCount > 0 then
        UPDATE Employee u
           set u.employee_name = pName,
               u.position      = pPosition,
               u.age           = pAge,
               u.salary        = pSalary
        
         where u.employee_id = pEmployee_Id;
      
      else
        perror_code := '-2000';
        perror_msg  := 'No data found';
      
      end if;
    
    EXCEPTION
      WHEN OTHERS THEN
        perror_code := SQLCODE;
        perror_msg  := SQLERRM;
      
    end;
  
  ELSIF pOption = 'Delete' Then
  
    BEGIN
    
      select nvl(count(a.employee_id), 0)
        into vCount
        from Employee a
       where a.employee_id = pEmployee_Id;
    
      if vCount > 0 then
      
        delete from Employee d where d.employee_id = pEmployee_Id;
      
      else
        perror_code := '-2000';
        perror_msg  := 'No data found';
      
      end if;
    
    EXCEPTION
      WHEN OTHERS THEN
        perror_code := SQLCODE;
        perror_msg  := SQLERRM;
      
    end;
  
  ELSIF pOption = 'GetById' Then
  
    BEGIN
    
      select nvl(count(a.employee_id), 0)
        into vCount
        from Employee a
       where a.employee_id = pEmployee_Id;
      if vCount > 0 then
      
        OPEN presult_set_cur FOR
          select * from Employee d where d.employee_id = pEmployee_Id;
      
      else
        perror_code := '-2000';
        perror_msg  := 'No data found';
      
      end if;
    
    EXCEPTION
      WHEN OTHERS THEN
        perror_code := SQLCODE;
        perror_msg  := SQLERRM;
      
    end;
    
    ELSIF pOption = 'GetAll' Then
  
    BEGIN
    
      
        OPEN presult_set_cur FOR
          select * from Employee;
      
    
    EXCEPTION
      WHEN OTHERS THEN
        perror_code := SQLCODE;
        perror_msg  := SQLERRM;
      
    end;
  
  else
    perror_code := '-2000';
    perror_msg  := 'No Option Found';
  
  end if;

EXCEPTION
  WHEN OTHERS THEN
    perror_code := SQLCODE;
    perror_msg  := SQLERRM;
  
END SP_Employee;
