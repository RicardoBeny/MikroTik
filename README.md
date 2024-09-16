# MikroTikController

## SDN Controller for Mikrotik

### Description
This project focuses on developing a simple SDN (Software Defined Networking) controller to manage network devices, specifically Mikrotik routers running RouterOS. The application connects to the devices via the RouterOS REST API to manage network configurations and implement a VPN using WireGuard.

### Features
- **Multi-device management**: Control multiple Mikrotik routers using the same application.
- **Interface management**:
  - List all network interfaces.
  - List wireless interfaces.
  - Create, edit, and delete bridge interfaces and associated ports.
- **Wireless network management**:
  - Create, edit, and delete security profiles for wireless networks.
  - Enable, disable, and configure wireless networks.
- **Static routes management**: Create, edit, and delete static routes.
- **IP address management**: Create, edit, and delete IP addresses.
- **DHCP server management**: Create, edit, and delete DHCP servers.
- **DNS server management**: Enable, disable, and configure DNS servers.

### VPN Configuration
- **VPN server/client setup**: Configure a VPN using WireGuard between clients (Windows, Linux, etc.) and the Mikrotik router, all managed through the developed application.
