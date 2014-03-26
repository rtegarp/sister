import xmlrpclib

proxy = xmlrpclib.ServerProxy("http://localhost:8000/")

print "1. Alamat Balai"
print "2. Pejabat BMKG"
print "3. Alamat Stasiun"
print "4. Cuaca Dunia"
print "5. Daerah Gelombang Tinggi"
print ""
choice = input('Pilih Nomor : ')
data_list = proxy.read_xml(choice)
i=0
while i< len(data_list):
    print data_list[i]
    i=i+1
proxy.empty_list()