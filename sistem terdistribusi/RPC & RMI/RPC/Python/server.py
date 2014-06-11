import xmllib
import urllib
from SimpleXMLRPCServer import SimpleXMLRPCServer

import xml.etree.ElementTree as ET

data_list = []

def read_xml(n):
    if n==1:
        url = "http://data.bmkg.go.id/alamatbalai.xml"
        doc = ET.parse(urllib.urlopen(url))
        root = doc.getroot()
        for Row in root.findall('Row'):
            balai = Row.find('Balai').text
            alamat = Row.find('Alamat').text
            telp = Row.find('telp').text
            fax = Row.find('fax').text
            kepalabal = Row.find('kepalabal').text
            data_list.append("Balai : " + balai)
            data_list.append("Alamat : " + alamat)
            data_list.append("telp : " + telp)
            data_list.append("fax : " + fax)
            data_list.append("kepalabal : " + kepalabal)
            data_list.append("")

    elif n==2:
        url = "http://data.bmkg.go.id/pejabatBBMKG1.xml"
        doc = ET.parse(urllib.urlopen(url))
        root = doc.getroot()
        for Pejabat in root.findall('Pejabat'):
            nama = Pejabat.find('Nama').text
            nip = Pejabat.find('NIP').text
            jabatan = Pejabat.find('Jabatan').text
            jabatan2 = Pejabat.find('Jabatan_EN').text
            eselon = Pejabat.find('Eselon').text
            email = Pejabat.find('email').text
            data_list.append("Nama : " + nama)
            data_list.append("NIP : " + nip)
            data_list.append("Jabatan : " + jabatan)
            data_list.append("Jabatan EN : " + jabatan2)
            data_list.append("Eselon : " + eselon)
            data_list.append("email : " + email)
            data_list.append("")

    elif n==3:
        url = "http://data.bmkg.go.id/alamatstasiun.xml"
        doc = ET.parse(urllib.urlopen(url))
        root = doc.getroot()
        for Row in root.findall('Row'):
            kota = Row.find('Kota').text
            stasiun = Row.find('Stasiun').text
            balai = Row.find('Balai').text
            alamat = Row.find('Alamat').text
            telp = Row.find('telp').text
            fax = Row.find('fax').text
            kepalasta = Row.find('kepalasta').text
            mail = Row.find('mail').text
            web = Row.find('web').text
            data_list.append("Kota : " + kota)
            data_list.append("Stasiun : " + stasiun)
            data_list.append("Balai : " + balai)
            data_list.append("Alamat : " + str(alamat))
            data_list.append("telp : " + str(telp))
            data_list.append("fax : " + fax)
            data_list.append("kepalasta : " + kepalasta)
            data_list.append("mail : " + mail)
            data_list.append("web : " + web)
            data_list.append("")

    elif n==4:
        url = "http://data.bmkg.go.id/cuaca_dunia_1.xml"
        doc = ET.parse(urllib.urlopen(url))
        root = doc.getroot()
        tanggal = root.find('Tanggal').text
        data_list.append("Tanggal : " + tanggal)
        data_list.append("")
        for Row in root.findall('Isi/Row'):
            kota = Row.find('Kota').text
            cuaca = Row.find('Cuaca').text
            suhumin = Row.find('SuhuMin').text
            suhumax = Row.find('SuhuMax').text
            data_list.append("Kota : " + kota)
            data_list.append("Cuaca : " + cuaca)
            data_list.append("SuhuMin : " + suhumin)
            data_list.append("SuhuMax : " + suhumax)
            data_list.append("")

    elif n==5:
        url = "http://data.bmkg.go.id/daerah_gelombang_tinggi.xml"
        doc = ET.parse(urllib.urlopen(url))
        root = doc.getroot()
        for Tanggal in root.findall('Tanggal'):
            mulai = Tanggal.find('Mulai').text
            sampai = Tanggal.find('Sampai').text
            data_list.append("Mulai : " + mulai)
            data_list.append("Sampai : " + sampai)
            data_list.append("")
        for Row in root.findall('Isi/Row'):
            tinggi = Row.find('Tinggi').text
            daerah = Row.find('Daerah').text
            data_list.append("Tinggi : " + tinggi)
            data_list.append("Daerah : " + daerah)
            data_list.append("")
    return data_list

def empty_list():
    data_list[:]=[]
    return "Oke"

server = SimpleXMLRPCServer(("localhost", 8000))
print ("Listening on port 8000 ...")
server.register_function(read_xml, "read_xml")
server.register_function(empty_list, "empty_list")
server.serve_forever()


