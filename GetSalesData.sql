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



select Sum(sp.Amount) as Sales, Sum(s.Cost) as Cost, Sum(sp.Amount - s.Cost) as Profit
from ServicesPerformed sp left outer join 
ServicesPerformedHasService sps on sps.ServicesPerformedID = sp.ServicesPerformedID left outer join
Service s on s.ServiceID = sps.ServiceID
where Date >= @From and Date < @To


select Sum(sp.Amount) as Sales, Sum(s.Cost) as Cost, Sum(sp.Amount - s.Cost) as Profit
from Estimate sp left outer join 
EstimateHasService sps on sps.EstimateID = sp.EstimateID left outer join
Service s on s.ServiceID = sps.ServiceID
where Date >= @From and Date < @To



select *,(Street + ' ' + City + ', ' + State + ' ' + ZipCode) as Address 
from Location l, LocationHasServicesPerformed lsp
where lsp.LocationID = l.LocationID and l.CustomerID = lsp.CustomerID

select * from Customer


select *,(FirstName + ' ' + LastName) as Name from Consultant c, BusinessConsultant bc where bc.EmployeeID = c.EmployeeID

select ServiceId, (CONVERT(varchar(10), ServiceId) + '-' + Description + ' $' + Convert(varchar(10),Cost)) as FullName from Service


declare @estimateId as int = 1;

select s.ServiceId, (CONVERT(varchar(10), s.ServiceId) + '-' + Description + ' $' + Convert(varchar(10),Cost)) as FullName 
from Service s, EstimateHasService ehs 
where s.ServiceId = ehs.ServiceID and ehs.EstimateID = @EstimateID