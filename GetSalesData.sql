declare @From as datetime = '12/5/2019';
declare @To as datetime = '3/5/2020';

select c.CompanyName, (co.FirstName + ' ' + co.LastName) as TechnicalConsultant, sp.Date, Sum(sp.Amount) as Sales, Sum(s.Cost) as Cost, Sum(sp.Amount - s.Cost) as Profit
from ServicesPerformed sp left outer join 
Customer c on sp.CustomerID = c.CustomerID left outer join
Consultant co on sp.TechnicalConsultantID = co.EmployeeID left outer join
ServicesPerformedHasService sps on sps.ServicesPerformedID = sp.ServicesPerformedID left outer join
Service s on s.ServiceID = sps.ServiceID
where Date >= @From and Date < @To
group by c.CompanyName, co.FirstName, co.LastName, sp.Date
